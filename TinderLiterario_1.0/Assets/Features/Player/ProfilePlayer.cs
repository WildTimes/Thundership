using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfilePlayer : MonoBehaviour
{

    [HideInInspector] public string playerName;
    [HideInInspector] public int age;
    [HideInInspector] public bool isMale;
    [HideInInspector] public List<Sprite> pictures;
    [HideInInspector] public string resume;
    [HideInInspector] public static ProfilePlayer Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        pictures = new List<Sprite>();
    }

    public void SetName(string newName)
    {
        // Esse método deve ser chamado no InputField de colocar o nome e conterá mais funcinalidade no futuro

        if (newName.Length <= 0)
        {
            Debug.Log("Impedir que o Usuário prossiga por falta de informação de Nome");
        }
        else
        {

            playerName = newName;

            Debug.Log("playerNameme do Usuário é: " + playerName);   
        }
    }

    public void SetAge(int newAge)
    {
        //Esse método deve ser chamado no Dropdown de selecionar a idade e pode vir a ter mais funções no futuro

        if (newAge <= 0)
        {
            Debug.Log("Impedir que o Usuário prossiga por falta de informação de Idade");
        }
        else
        {
            age = newAge + 2;
            //soma 2 oporque a idade começa em 3 anos
            Debug.Log("O Usuário tem " + age + " anos.");
        }
    }

    public void SetGender(bool gender)
    {
        //Esse método deve ser chamado no Dropdown de selecionar gênero e terá mais funções no futuro, incluindo a troca de pronomes no texto

        isMale = gender;
        if (isMale)
        {
            Debug.Log("O Usuário será referenciado com pronomes Masculinos");
        }
        else
        {
            Debug.Log("O Usuário será referenciado com pronomes Femininos");
        }
    }

    public void SetResume(string newResume)
    {
        if (newResume.Length <= 0)
        {
            Debug.Log("Avisar o Usuário que ele não colocou um Resumo");
        }
        else
        {
            resume = newResume;
            Debug.Log(resume);
        }
    }

    public void AddPicture(Sprite newPicture)
    {
        if (pictures.Contains(newPicture))
        {
            return;
        }
        else
        {
            Debug.Log("Foto " + newPicture.name + " foi adicionada ao álbum do Usuário");
            pictures.Add(newPicture);
        }
    }
}
