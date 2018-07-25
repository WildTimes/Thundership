using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllowContinue : MonoBehaviour
{

    private Button myBtn;
    private string nameToSet;
    private int ageToSet;
    private bool genderToSet;
    private string resumeToSet;

    void Awake()
    {
        myBtn = GetComponent<Button>();
    }

    public void CheckForValidName(string name)
    {
        if (name != null)
        {
            myBtn.interactable = true;
            nameToSet = name;
        }
        else
        {
            myBtn.interactable = false;
        }
    }

    public void CheckForValidAge(int age)
    {
        if (age > 0)
        {
            myBtn.interactable = true;
            ageToSet = age;
        }
        else
        {
            myBtn.interactable = false;
        }
    }

    public void CheckForValidGender(int dropDownIndex)
    {
        if (dropDownIndex == 0)
        {
            myBtn.interactable = false;
        }
        else
        {
            myBtn.interactable = true;

            if (dropDownIndex == 1)
            {
                genderToSet = true;
            }
            else
            {
                genderToSet = false;
            }
        }
    }

    public void CheckForValidResume(string resume)
    {
        if (resume.Length <= 0)
        {
            myBtn.interactable = false;
        }
        else
        {
            myBtn.interactable = true;
            resumeToSet = resume;
        }
    }

    public void SetName()
    {
        ProfilePlayer.Instance.SetName(nameToSet);
    }

    public void SetAge()
    {
        ProfilePlayer.Instance.SetAge(ageToSet);
    }

    public void SetGender()
    {
        ProfilePlayer.Instance.SetGender(genderToSet);
    }

    public void SetResume()
    {
        ProfilePlayer.Instance.SetResume(resumeToSet);
    }
}
