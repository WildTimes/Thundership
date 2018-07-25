using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageOption : MonoBehaviour
{
    private ChatController chatController;

    private Text myMessageTextBox;

    private int iniciolinha;
    private int finallinha;
    private string message;
    private List<string> friendanswers;
    private testedeenvio envio;

    void Awake()
    {
        chatController = FindObjectOfType<ChatController>();
        myMessageTextBox = GetComponentInChildren<Text>();

        envio = FindObjectOfType<testedeenvio>();



    }

    public void UpdateOptionButton( string messageoption, string[] friendanswer)
    {
        message = messageoption;
        myMessageTextBox.text = message;
        friendanswers = new List<string>(friendanswer);
        //iniciolinha = inicial;
        //finallinha = final;
    }

    public void SendMyMessage()
    {
        chatController.SendMessageToChat(message, true);
        chatController.FriendAnswer(friendanswers);
        //print(iniciolinha + "," + finallinha);
        //envio.ChamaCoisa(0);
    }
}
