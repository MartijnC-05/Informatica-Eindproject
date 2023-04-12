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
    public AudioClip audioClip2;
    public bool played = true;
    private bool Done = false;


    public void play()
    {
        if (DIEDIEDIE.instance.Died == false)
        {
            played = false;
        }
    }


    public void Boom()
    {
        if (Quests.instance.questcomplete == true)
        {
            if (Done == false)
            {
                audioSource = GetComponent<AudioSource>();
                audioSource.clip = audioClip2;
                audioSource.loop = false;
                audioSource.Play();
                Done = true;
            }
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
