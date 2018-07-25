using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FiendatLob : MonoBehaviour {

    public Card card;

    private Text headName;
    private Image headImage;

    private GameObject parent;

    void Awake()
    {
        parent = GameObject.Find("Canvas");
        headImage = parent.transform.Find("ChatScreen/HeadMessage/FriendImageChat").GetComponent<Image>();
        headName = parent.transform.Find("ChatScreen/HeadMessage/FriendNameChat").GetComponent<Text>();
    }

    public void InfoToChat()
    {
        //infotochat.ReceiveInfoToChat(card);
        headImage.sprite = card.cardImage;
        headName.text = card.cardName;

        parent.transform.Find("ChatScreen").gameObject.SetActive(true);
    }
}
