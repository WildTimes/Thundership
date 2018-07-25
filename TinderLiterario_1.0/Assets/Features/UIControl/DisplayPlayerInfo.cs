using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPlayerInfo : MonoBehaviour
{

    [SerializeField] private Text nameTxt;
    [SerializeField] private Text ageTxt;
    [SerializeField] private Text genderTxt;
    [SerializeField] private Text resumeTxt;

    void OnEnable()
    {
        nameTxt.text = ProfilePlayer.Instance.playerName;
        ageTxt.text = ProfilePlayer.Instance.age.ToString();
        if (ProfilePlayer.Instance.isMale)
        {
            genderTxt.text = "Masculino";   
        }
        else
        {
            genderTxt.text = "Feminino";
        }
        resumeTxt.text = ProfilePlayer.Instance.resume;
    }
}
