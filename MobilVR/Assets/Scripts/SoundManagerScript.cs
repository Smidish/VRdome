using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip CallBot;
    public static AudioClip CaDeepER;
    public static AudioClip TranslateApp;
    public static AudioClip CrmBot;

    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        CallBot = Resources.Load<AudioClip>("sound1");
        audioSrc = GetComponent<AudioSource>();
    }

    public static void playSound()
    {
        audioSrc.PlayOneShot(CallBot);
        Debug.Log("hi");
    }
}
