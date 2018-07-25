using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FriendInfoToChat : MonoBehaviour {

    public Image friendImageChat;
    public Text friendNameChat;
    public Image friendminiature;

    public void ReceiveInfoToChat(Card friendInfo)
    {
        friendImageChat.sprite = friendInfo.cardImage;
        friendNameChat.text = friendInfo.cardName;
        friendminiature.sprite = friendInfo.cardImage;
    }
}
