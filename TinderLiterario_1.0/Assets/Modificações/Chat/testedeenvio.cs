using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testedeenvio : MonoBehaviour {
    
    ChatController chatt;
    public Sprite fotenha;
    public string legendafotenha; 
    //public List<string> opcoes;

    public DialogosData[] datas = {};

    private int Line;
    /*private int LineEnd;
    private List <string> optionsList = new List<string>();
    private List <string[]> optionsAnswers = new List<string[]>();
    */

    // Use this for initialization
	void Start () {

        chatt = FindObjectOfType<ChatController>();

        DataPool.initpool();

        datas = DataPool.m_sheet.dataArray;

        //LineStr = 0;

        //ChamaCoisa(Line);

		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.A))
        {
            ChamaCoisa(Line);
        }
		
        if (Input.GetKeyDown(KeyCode.D))
        {
            chatt.SendImageToChat(fotenha);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            chatt.SendContactToChat (fotenha, legendafotenha);
        }
	}

    public void ChamaCoisa( int Num)
    {
        /*
         //int LineStr = 0;
         //int LineEnd = 0;
         List <string> optionsList = new List<string>();
         List <string[]> optionsAnswers = new List<string[]>();


        //print(startNum+","+ endNum);
       
        for (int i = startNum; i < endNum; i++)
        {
            LineStr = datas[i].Linhainicio;

            LineEnd = datas[i].Linhafim;

            optionsList.Add(datas[i].Frases_player);

            optionsAnswers.Add(datas[i].Respostas_friend);
        }

        print(optionsList.Count);
        print(optionsAnswers.Count);
        */

        /*
        Line = datas[Num].Linhainicio;

            string[] str = datas[Num].Frases_player;
            for (int j = 0; j < str.Length; j++)
            {
                optionsList.Add(str[j]);
                print(str[j]);
            }
            
        print(optionsList.Count);

        optionsAnswers.Add(datas[Num].Respostas_friend);
        */
        List <string[]> optionsList = new List<string[]>();
        List <string[]> optionsAnswers = new List<string[]>();


        optionsList.Add(datas[Num].Frases_player);
        optionsAnswers.Add(datas[Num].Respostas_friend);

        chatt.RevealNextMessageOptions(optionsList, optionsAnswers, datas[Num].Linhainicio);
    }

//    public void teste()
//    {
//        print(LineStr + "," + LineEnd);
//        ChamaCoisa(Line);
//    }
}


public class DataPool
{
    public static Dialogos m_sheet;

    public static void initpool()
    {

        m_sheet = Resources.Load<Dialogos>("Data/Excel/Dialogos"); // precisa estar dentro da pasta resources no Assets
  
    }
}
