﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public static Sound_Manager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SFXPlay(string sfxName, AudioClip clip)
    {
        if (clip)
        {
            GameObject go = new GameObject(sfxName + "Sound");
            AudioSource audioSource = go.AddComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.Play();
            Destroy(go, clip.length);
        }
    }
}
