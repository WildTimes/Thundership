using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileGenderImage : MonoBehaviour
{
    [SerializeField] private Sprite[] genderSprites;

    private Image display;

    void Awake()
    {
        display = GetComponent<Image>();
    }

    public void SetGenderSprite(int genderIndex)
    {
        if (genderIndex == 0)
        {
            display.sprite = null;
        }
        else if (genderIndex == 1)
        {
            display.sprite = genderSprites[0];
        }
        else if (genderIndex == 2)
        {
            display.sprite = genderSprites[1];
        }
    }
}
