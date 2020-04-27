using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "AudioManager ", menuName = "Audio Settings ")]
public class AudioSettings : ScriptableObject 
{
    
    //Volume controls
    public float MusicVolume;
    public float SFXVolume;
    public float MasterVolume;


    private void Awake()
    {
        MusicVolume = PlayerPrefs.GetFloat("MusicVolume", MusicVolume);
        MasterVolume = PlayerPrefs.GetFloat("MasterVolume", MasterVolume);
        SFXVolume = PlayerPrefs.GetFloat("SFXVolume", SFXVolume);
    }
}
