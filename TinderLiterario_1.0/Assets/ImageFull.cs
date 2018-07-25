using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ImageFull : MonoBehaviour {

    private Image picture;
    private Text subtitle;

    private GameObject parent;
    void OnEnable()
    {
        parent = GameObject.Find("Canvas");
        picture= parent.transform.Find("Image FullScreen/Image").GetComponent<Image>();
        subtitle= parent.transform.Find("Image FullScreen/Panel/Text").GetComponent<Text>();

    }

    public void GetPicture()
    {
        picture.sprite = transform.Find("SentImage").GetComponent<Image>().sprite;
        subtitle.text = transform.Find("SentText").GetComponent<Text>().text;

        if (subtitle.text != "")
        {
            parent.transform.Find("Image FullScreen/Panel").gameObject.SetActive(true);
        }

        parent.transform.Find("Image FullScreen").gameObject.SetActive(true);
    }
}
