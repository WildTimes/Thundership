using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenderDropdownPicture : MonoBehaviour
{

    private ProfilePlayer playerProfile;

    void Awake()
    {
        playerProfile = ProfilePlayer.Instance;
    }

}
