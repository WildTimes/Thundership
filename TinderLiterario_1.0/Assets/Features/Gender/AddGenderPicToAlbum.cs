using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddGenderPicToAlbum : MonoBehaviour
{
    private ProfilePlayer profilePlayer;

    private Dropdown dropdown;

    void Awake()
    {
        dropdown = GetComponent<Dropdown>();
    }

    void Start()
    {
        profilePlayer = ProfilePlayer.Instance;
    }

    public void AddOptionPicture()
    {
        int currentOptionIndex = dropdown.value;
        Sprite currentOptionSprite = dropdown.options[currentOptionIndex].image;

        if (currentOptionSprite != null)
        {
            Debug.Log(currentOptionSprite);
            profilePlayer.AddPicture(currentOptionSprite);
        }
    }
}
