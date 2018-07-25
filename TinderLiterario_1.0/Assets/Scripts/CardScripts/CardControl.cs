using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CardControl : MonoBehaviour
{
    public GameObject cardReference;
    public Card[] cards;

    private GameObject myTransform;

    private List<GameObject> cardList;
    //private List<GameObject> cardscanvastemp;

    private int currentCardIndex;
    private GameObject currentCard;

    private bool firstActive;

    private SwipeableObject swipeObj;
    private UiinCard uiObj;

    void Start()
    {
        myTransform = this.gameObject;
        firstActive = false;
        cardList = new List<GameObject>();

        //isntacia as cartas com as informações dos cards
        for (int i = 0; i < cards.Length; i++)
        {
            var go = Instantiate(cardReference, myTransform.transform) as GameObject;

            go.gameObject.name = (1 + i).ToString();

            cardList.Add(go);

            cardList[i].GetComponentInChildren<UiinCard>().card = cards[i];
            //cardList[i].SetActive(false);
        }

        //currentCard = cardList[0];
        //currentCard.SetActive(true);
		cardList[cards.Length - 1].GetComponentInChildren<SwipeableObject>().canSwipe = true;
    }

   /* public void NextCard()
    {
        //Controla todo processo de trazer a próxima carta


        //desativa a carta atual
        currentCard.SetActive(false);

        //seleciona a próxima carta
        if (currentCardIndex < cardList.Count - 1)
        {
            currentCardIndex++;
        }
        else
        {
            currentCardIndex = 0;
        }

        currentCard = cardList[currentCardIndex];

        //reativa a carta atual que foi trocada
        currentCard.SetActive(true);
    }*/

	public void NextCard2()
	{

		cardList[cards.Length - 1].transform.SetSiblingIndex(0);
		cardList = ListUpdate(cardList);
		Canvas.ForceUpdateCanvases();
		for (int i = cardList.Count-2; i < cardList.Count; i++) 
		{
			cardList [i].gameObject.SetActive (true);
		}

		if (cardList[cards.Length - 1].activeInHierarchy)
		{
			cardList[cards.Length - 1].GetComponentInChildren<SwipeableObject>().canSwipe = true;
		}
	}

    private List<GameObject> ListUpdate(List<GameObject> cardsList)
    {
        List<GameObject> cardsListTemp;

        cardsListTemp = new List<GameObject>();

        cardsListTemp.Add(cardsList[cardsList.Count - 1]);

        for (int i = 0; i < cardsList.Count - 1; i++)
        {
            cardsListTemp.Add(cardsList[i]);
        }

        return cardsListTemp;
    }
		
}
