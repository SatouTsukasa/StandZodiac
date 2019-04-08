﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MugicRoom : MonoBehaviour
{
    
    private bool AudioPlay;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void Button_audioPlay() {

        if (AudioPlay == true)
        {
            audioSource.Stop();
        }

        audioSource.Play();
        AudioPlay = true;
    }
    
}
