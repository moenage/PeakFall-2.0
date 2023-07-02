using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip backgroud;
    public AudioClip jump;
    public AudioClip landingPlatform;

    AudioSource backgroundSource;
    AudioSource jumpSource;
    AudioSource landingPlatformSource;


    void Start()
    {
        instance = this;

        backgroundSource = gameObject.AddComponent<AudioSource>();
        jumpSource = gameObject.AddComponent<AudioSource>();
        landingPlatformSource = gameObject.AddComponent<AudioSource>();

        backgroundSource.loop = true;
        backgroundSource.clip = backgroud;
        //backgroundSource.Play();
    }

    public void jumping()
    {
        jumpSource.clip = jump;
        jumpSource.Play();
    }

    public void landing()
    {
        landingPlatformSource.clip = landingPlatform;
        landingPlatformSource.Play();
    }


    


   
}
