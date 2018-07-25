using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InfoToProfile : MonoBehaviour {

    public Card card;

    private Image pImage;
    private Text pName;
    private Text pAge;
    private Text pDescription;

    private GameObject parent;

    void Start()
    { 
        if (this.name == "ProfileButton")
        {
            card = this.transform.parent.gameObject.transform.Find("Pts").GetComponent<UiinCard>().card;
        }

        parent= GameObject.Find("Canvas");
        pImage= parent.transform.Find("ProfileScreen/NpcImage").GetComponent<Image>();

        pName= parent.transform.Find("ProfileScreen/NpcName").GetComponent<Text>();

        pAge=parent.transform.Find("ProfileScreen/NpcAge").GetComponent<Text>();

        pDescription= parent.transform.Find("ProfileScreen/NpcDescription/Text").GetComponent<Text>();
    }

    public void OpenProfile()
    {

        pImage.sprite= card.cardImage;
        pName.text= card.cardName;
        pAge.text = card.cardAge.ToString();
        pDescription.text= card.cardDescription;

        parent.transform.Find("ProfileScreen").gameObject.SetActive(true);

    }
	



}

