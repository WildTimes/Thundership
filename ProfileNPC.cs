using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileNPC : ScriptableObject
{

    [HideInInspector] public string name;
    [HideInInspector] public int age;
    [HideInInspector] public bool isMale;
    [HideInInspector] public string resume;
    [HideInInspector] public Sprite[] pictures;
    private int affinity;
}
