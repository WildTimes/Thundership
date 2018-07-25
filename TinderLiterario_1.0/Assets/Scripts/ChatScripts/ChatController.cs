using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ChatController : MonoBehaviour
{
    private AudioSource globalAudioSource;

    [SerializeField] private Transform answerPanel;
    [SerializeField] private GameObject answerPrefab;

    [SerializeField] private GameObject chatScreen;

    private GameObject[] answerOptions;

    public int maxMessages;

    public GameObject chatPanel;
    public GameObject playerText;
    public GameObject friendText;
    public GameObject notificationBtn;

    List<Message> messageList;

    private bool canSendMessage;

    [SerializeField] private float answerDelay;
    [SerializeField] private float notificationDuration;

    private testedeenvio envio;
    private int nextLine;
    public Sprite fotenha;

    void Start()
    {
        envio = FindObjectOfType<testedeenvio>();

        globalAudioSource = FindObjectOfType<AudioSource>();
        answerOptions = new GameObject[10];
        messageList = new List<Message>();
        canSendMessage = true;

        if (maxMessages <= 0)
        {
            maxMessages = 30;
        }
    
    }
        
    // envia as mensagens do npc com um delay.
    public IEnumerator MessagesDelay( List<string> answers, int timedelay)
    {
        foreach (string answer in answers)
        {
            yield return new WaitForSeconds(timedelay);

            string temp = answer.Substring(0, 1); // verifica o primeiro item da string

            int index;
            Sprite sprite;

            switch (temp)
            {

                case "#":
                    sprite = Resources.Load<Sprite>("Arts/ImageProfiles/" + answer.Substring(1));
                    SendImageToChat(sprite);
                    break;
                case"@":
                    index = answer.IndexOf('-');
                    sprite = Resources.Load<Sprite>("Arts/ImageProfiles/" + answer.Substring(1,(index-1)));
                    SendImageToChat(sprite, answer.Substring((index+1)));
                    break;
                case"%":
                    index = answer.IndexOf('-');
                    sprite = Resources.Load<Sprite>("Arts/ImageProfiles/" + answer.Substring(1,(index-1)));
                    SendContactToChat(sprite, answer.Substring((index+1)));
                    break;
                default:
                    SendMessageToChat(answer, false);
                    break;
            
            }
            //SendMessageToChat(answer, false);
            globalAudioSource.PlayOneShot(Globals.MESSAGE_RECEIVE);
        }

        //RevealNextMessageOptions();

        //chamar proximas respostas

        envio.ChamaCoisa(nextLine);
    }


    IEnumerator Notification()
    {
        globalAudioSource.PlayOneShot(Globals.MESSAGE_NOTIFICATION);

        notificationBtn.SetActive(true);
        yield return new WaitForSeconds(notificationDuration);
        notificationBtn.SetActive(false);
    }

    //gera as respostas do npc.
    public void FriendAnswer(List<string> answerlist)
    {
        canSendMessage = false;

        StartCoroutine(MessagesDelay(answerlist,Random.Range(1,3)));


        if (!chatScreen.activeInHierarchy)
        {
            StartCoroutine(Notification());
        }

    }

    //cria os botoes com as respostas do jogador 
    public void RevealNextMessageOptions( List<string[]> choisesmessage, List<string[]> answers, int next)
    {
        /*for (int i = 0; i < choisesmessage.Count; i++)
        {

            Instantiate(answerPrefab, answerPanel);
            answerOptions[i] = answerPanel.GetChild(i).gameObject;
            answerOptions[i].GetComponent<MessageOption>().UpdateOptionButton(choisesmessage[i], answers[i]);

        }*/

        string[] str = choisesmessage[0];
        string[] astr = answers[0];

        for (int i = 0; i < str.Length; i++)
        {
            Instantiate(answerPrefab, answerPanel);
            answerOptions[i] = answerPanel.GetChild(i).gameObject;

            string[] temp = astr[i].Split(',');

            answerOptions[i].GetComponent<MessageOption>().UpdateOptionButton(str[i], temp);

        }

        nextLine= (next-1);
        canSendMessage = true;
    }

    //envio de mensagem para os elementos do canvas e para a lista de mensagens.
    public void SendMessageToChat(string text, bool isMessageFromPlayer)
    {
        GameObject newText;
        Message newMessage = new Message();


        if (messageList.Count >= maxMessages)
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);
        }
			

        newMessage.text = text;

        newText = Instantiate(
            isMessageFromPlayer ? playerText : friendText,
            chatPanel.transform);

        newMessage.textObject = newText.transform.Find("MessageBackGround/SentText").GetComponent<Text>();

        newMessage.textObject.text = newMessage.text;

        messageList.Add(newMessage);

        UpdateLayoutGroup(newText);
        

        if (isMessageFromPlayer)
        {
            globalAudioSource.PlayOneShot(Globals.MESSAGE_SEND);
            DestroyCurrentMessageOptions();
        }
    }

    //Envio só de imagem para o chat
    public void SendImageToChat(Sprite friendImage)
    {
        GameObject newText;
        Message newMessage = new Message();


        if (messageList.Count >= maxMessages)
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);
        }


        newMessage.text = friendImage.name;

        newText = Instantiate( friendText, chatPanel.transform);

        newText.transform.Find("MessageBackGround/SentImage").gameObject.SetActive(true); //Ativa componente da imagem

        newText.transform.Find("MessageBackGround/SentImage").GetComponent<Image>().sprite = friendImage;
        newText.transform.Find("MessageBackGround/SentText").gameObject.SetActive(false);

        messageList.Add(newMessage);

        /*foreach (Message st in messageList)
        {
            print(st.text);
        }*/

        UpdateLayoutGroup(newText);
    }

    //Envio de imagem com legenda para o chat
    public void SendImageToChat(Sprite friendImage, string text)
    {
        GameObject newText;
        Message newMessage = new Message();


        if (messageList.Count >= maxMessages)
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);
        }


        newMessage.text = text;

        newText = Instantiate( friendText, chatPanel.transform);

        newText.transform.Find("MessageBackGround/SentImage").gameObject.SetActive(true); //Ativa componente da imagem

        newMessage.textObject = newText.transform.Find("MessageBackGround/SentText").GetComponent<Text>();

        newText.transform.Find("MessageBackGround/SentImage").GetComponent<Image>().sprite = friendImage;

        newMessage.textObject.text = newMessage.text;

        messageList.Add(newMessage);

        /*foreach (Message st in messageList)
        {
            print(st.text);
        }*/

        UpdateLayoutGroup(newText);
    }

    //Envio de Contato para o chat
    public void SendContactToChat(Sprite friendImage, string text)
    {
        GameObject newText;
        Message newMessage = new Message();


        if (messageList.Count >= maxMessages)
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);
        }


        newMessage.text = text;

        newText = Instantiate( friendText, chatPanel.transform);

        newText.transform.Find("MessageBackGround/Contato").gameObject.SetActive(true); //Ativa componente do contato

        newText.transform.Find("MessageBackGround/SentText").GetComponent<Text>().text = "Contato"; //Adiciona a palavra "Contato" ao texto da mensagem

        newMessage.textObject = newText.transform.Find("MessageBackGround/Contato/Text").GetComponent<Text>();

        newText.transform.Find("MessageBackGround/Contato/Button").GetComponent<Image>().sprite = friendImage;

        newMessage.textObject.text = newMessage.text;

        messageList.Add(newMessage);

        /*foreach (Message st in messageList)
        {
            print(st.text);
        }*/

        UpdateLayoutGroup(newText);
    }



    //apaga opções do player depois que a mensagem foi enviada.
    void DestroyCurrentMessageOptions()
    {
        for (int i = 0; i < answerOptions.Length; i++)
        {
            Destroy(answerOptions[i]);   
        }
    }

    //Utilizado para atualizar as posições dentro dos grupos.
    void UpdateLayoutGroup( GameObject RectObject)
    {
        RectTransform rectT = RectObject.GetComponent<RectTransform>();

        LayoutRebuilder.ForceRebuildLayoutImmediate(rectT);
    }
}

public class Message
{
    public string text;
    public Text textObject;
}