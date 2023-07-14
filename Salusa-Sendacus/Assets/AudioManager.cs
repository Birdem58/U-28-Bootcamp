using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sounds[] musicSounds, efectSounds, mainSounds;
    public AudioSource musicSource, efectSource, mainSource;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

        private void Start()
    {
            PlayMusic("GameMusic");
    }

    public void PlayMusic (string name)
    {
        Sounds s = Array.Find(musicSounds, x => x.name == name);

        if (s==null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlayEfect(string name)
    {
        Sounds s = Array.Find(efectSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            efectSource.PlayOneShot(s.clip);
        }
    }
    public void PlayMain(string name)
    {
        Sounds s = Array.Find(mainSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            mainSource.clip = s.clip;
            mainSource.Play();
        }
    }
}
