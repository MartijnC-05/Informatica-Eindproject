using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public static Audio instance;
    private void Awake()
    {
        instance = this;
    }

    AudioSource audioSource;
    public AudioClip audioClip;
    public bool played = true;

    public void play()
    {
        if (DIEDIEDIE.instance.Died == false)
        {
            played = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (DIEDIEDIE.instance.Died == true)
        {
            if (played == false)
            {
                audioSource = GetComponent<AudioSource>();
                audioSource.clip = audioClip;
                audioSource.loop = false;
                audioSource.Play();
                played = true;
            }
        }
    }
}
