using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetProfileAgeDropdownOptions : MonoBehaviour
{
    List<string> options;
    Dropdown dropdown;

    void Awake()
    {
        options = new List<string>();

        options.Add("Idade");
        for (int i = 3; i < 120; i++)
        {
            options.Add(i.ToString());
        }
    }

    void Start()
    {
        //Fetch the Dropdown GameObject the script is attached to
        dropdown = GetComponent<Dropdown>();
        //Clear the old options of the Dropdown menu
        dropdown.ClearOptions();
        //Add the options created in the List above
        dropdown.AddOptions(options);
    }
}
