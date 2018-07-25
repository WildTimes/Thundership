using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UiinCard : MonoBehaviour
{

    public Card card;

    public GameObject backTextPoint;
    public GameObject namePoint;
    public GameObject descriptionPoint;
    public GameObject LikePoint;
    public GameObject NopePoint;

    public Image cardImage;
    public Image cardBackText;
    public Image likeImage;
    public Image nopeImage;

    public Text cardName;
    public Text cardDescription;

    private Transform myTransform;

    private Camera cam;

	private SwipeScript swipeRef;
	private SwipeableObject swipeObj;

    void Start()
    {
        cam = Camera.main;

        cardImage.sprite = card.cardImage; 
        cardName.text = card.cardName;
        cardDescription.text = card.cardDescription;

		swipeRef= FindObjectOfType<SwipeScript>();
		swipeObj = GetComponent<SwipeableObject> ();

        myTransform = GetComponent<Transform>();
    }
	
    void Update()
    {
        // Posiciona os elemntos do canvas conforme as posições dos objetos dentro da cena. inclusive a movimentação;
        cardImage.transform.position = cam.WorldToScreenPoint(myTransform.position);
        cardBackText.transform.position = cam.WorldToScreenPoint(backTextPoint.transform.position);
        cardName.transform.position = cam.WorldToScreenPoint(namePoint.transform.position);
        cardDescription.transform.position = cam.WorldToScreenPoint(descriptionPoint.transform.position);
		likeImage.transform.position = cam.WorldToScreenPoint(LikePoint.transform.position);
		nopeImage.transform.position = cam.WorldToScreenPoint(NopePoint.transform.position);

        cardImage.transform.rotation = myTransform.rotation;
        cardBackText.transform.rotation = backTextPoint.transform.rotation;
        cardName.transform.rotation = namePoint.transform.rotation;
        cardDescription.transform.rotation = descriptionPoint.transform.rotation;
		likeImage.transform.rotation = LikePoint.transform.rotation;
		nopeImage.transform.rotation = NopePoint.transform.rotation;


				if (myTransform.rotation.z <= 0) 
				{
					likeImage.GetComponent<Image> ().color = new Color (255, 255, 255, Mathf.Abs (myTransform.rotation.z) * 10);
				} 
				if(myTransform.rotation.z >= 0) 
				{
					nopeImage.GetComponent<Image> ().color = new Color (255, 255, 255, Mathf.Abs (myTransform.rotation.z) * 10);
				}
    }



}
