using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips;

    public static AudioClip MENU_CLICK;

    public static AudioClip MESSAGE_LIKE;
    public static AudioClip MESSAGE_NOTIFICATION;
    public static AudioClip MESSAGE_RECEIVE;
    public static AudioClip MESSAGE_SEND;

    public static AudioClip PROFILE_DISLIKE;
    public static AudioClip PROFILE_LIKE;
    public static AudioClip PROFILE_MATCH;

    void Awake()
    {
        MENU_CLICK = audioClips[0];

        MESSAGE_LIKE = audioClips[1];
        MESSAGE_NOTIFICATION = audioClips[2];
        MESSAGE_RECEIVE = audioClips[3];
        MESSAGE_SEND = audioClips[4];

        PROFILE_DISLIKE = audioClips[5];
        PROFILE_LIKE = audioClips[6];
        PROFILE_MATCH = audioClips[7];
    }
}
