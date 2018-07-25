using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SwipeableObject : MonoBehaviour
{
    public float swipeVelocity;
    //velocidade em que a carta é arrastada
    public float returnVelocity;
    // velocidade em que a carta retorna
    public float rotationAngle;
    // angulo de rotação que a carta faz para sair da tela
    public float screenPart;
    // porcentagem da tela que será usada para definir os limites nos dois  lados;

    private Vector3 rigthLimit;
    // o ponto especifico na tela que é usado com limite; passando desse limite ele entende que foi selecionado.
    private Vector3 leftLimit;
    // o ponto especifico na tela que é usado com limite; passando desse limite ele entende que foi selecionado.
    private Vector3 finalMove;
    // continua movimentação da carta para direita ou para esquerda;

    private SwipeScript swipe;
    // elemento de Swipe, que verifica se esta ou nao sendo arrastado na tela.
    private CardControl cardController;

    private RectTransform myTransform;
    private Vector3 originalPosition;
    // posição de retorno da carta
    private Quaternion originalRotation;
    // rotação de retorno da carta


    public bool outLimit;
    public bool canSwipe;
    public bool outView;
	public bool liked;

	public LikeKind likekind;

    public Image  ponto1;
    public Image  ponto2;

	public enum LikeKind {Like, Slike, Nope}

    void Awake()
    {
        cardController = FindObjectOfType<CardControl>();
        swipe = FindObjectOfType<SwipeScript>();
        myTransform = this.GetComponent<RectTransform>();
    }

    void OnEnable()
    {
        /////TROCAR TUDO POR myTransform.anchoredPosition;

        canSwipe = false;
        swipeVelocity = 50f;
        returnVelocity = 10;
        rotationAngle = -8;
            screenPart = Screen.width / 4;

        Reset();

        originalPosition = transform.position;
        originalRotation = transform.rotation;

        /*rigthLimit = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width - screenPart, Screen.height / 2));
        leftLimit = Camera.main.ScreenToWorldPoint(new Vector2(0 + screenPart, Screen.height / 2));*/

        rigthLimit = new Vector2((Screen.width*2)- screenPart, Screen.height);
        leftLimit = new Vector2((Screen.width*-1) + screenPart, Screen.height);

        ponto1.transform.position = rigthLimit;
        ponto2.transform.position = leftLimit;
    }

    void OnDisable()
    {
        myTransform.position = originalPosition;
        myTransform.rotation = originalRotation;
        Reset();
    }

    void Update()
    {
        print(myTransform.position);
        //print(rigthLimit +","+ leftLimit);

        //verifica se pode ser arrastado
        if (canSwipe)
        {
	        // verifica se estão arrastando o dedo na tela
	        if (swipe.isSwiping)
	        {
	            // verifica se é para direita ou para esqueda
	            if (swipe.swipeRight)
	            {
					finalMove = swipe.deltaMove;
	                MoveCard(swipe.deltaMove);
	            }
	            
	            if (swipe.swipeLeft)
	            {
					finalMove = swipe.deltaMove;
	                MoveCard(swipe.deltaMove);
	            }
	        }

			// reposiciona e rotaciona a carta caso seja diferente da posição que começou no jogo e esteja dentro do limite para continuar na tela
				else if ((myTransform.position != originalPosition || myTransform.rotation != originalRotation) && !outLimit)
	        {
	            //myTransform.position = Vector3.Lerp(myTransform.position, originalPosition, Time.deltaTime * returnVelocity);
                myTransform.position = Vector3.Lerp(myTransform.position, originalPosition, Time.deltaTime * returnVelocity);

	            myTransform.rotation = Quaternion.Lerp(myTransform.rotation, originalRotation, Time.deltaTime * returnVelocity);
	        }
       }

        // verifica se esta dentro do limite para continuar na tela 
        if (myTransform.position.x >= rigthLimit.x || myTransform.position.x <= leftLimit.x)
        {
            outLimit = true;
        }
        else
        {
            outLimit = false;
        }

        // se extrapolar o limite e não estiverem mais arrastando na tela a carta sai da tela.
        if (outLimit && !swipe.isSwiping && myTransform.position != originalPosition)
        {
            if (this.transform.parent.gameObject.activeInHierarchy)
            {
                MoveCard(finalMove);

				if (myTransform.rotation.z < 0)
					liked = true;
				else
					liked = false;

				/*switch (likekind) 
				{
					case LikeKind.Like:
					break;

					case LikeKind.Slike:
					break;

					case LikeKind.Nope:
					break;
				}*/
				//cardController.NextCard2();
                //this.transform.parent.gameObject.SetActive(false);
            }
        }

    }

    // movimenta o card na posição  da direção em que foi arrastado;
    void MoveCard(Vector3 deltaDirection)
    {
        Vector3 tempPosition = myTransform.position;

        tempPosition.x += deltaDirection.x * (Time.deltaTime / swipeVelocity);
        myTransform.position = tempPosition;
        myTransform.rotation = Quaternion.Euler(0, 0, tempPosition.x * rotationAngle); 
    }

    public void Reset()
    {
        outLimit = false;
        outView = false;
    }
}
