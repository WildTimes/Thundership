using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveChat : MonoBehaviour {

    private testedeenvio envio;
    private bool first;

    void Awake()
    {
        envio = FindObjectOfType<testedeenvio>();
    }

    void OnEnable()
    {
        if (!first)
        {
            envio.ChamaCoisa(0);
            first = true;
        }
    }
}
