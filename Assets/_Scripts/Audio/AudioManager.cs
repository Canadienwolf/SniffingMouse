using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    FMOD.Studio.EventInstance SFXVolumeTestEvent;

    //Game Managers (Scriptable Object)
    //public AudioSettings GSAudioManager;
    
    //Fmod connections
    public FMOD.Studio.Bus Music;
    public FMOD.Studio.Bus SFX;
    public FMOD.Studio.Bus Master;

    //Volume controls
    public static float MusicVolume;
    public static float SFXVolume;
    public static float MasterVolume;
    public static AudioManager instance;

    private void Awake()
    {
        
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        
        
        
        DontDestroyOnLoad(this);

        Music = FMODUnity.RuntimeManager.GetBus("bus:/Master/Music");
        SFX = FMODUnity.RuntimeManager.GetBus("bus:/Master/SFX");
        Master = FMODUnity.RuntimeManager.GetBus("bus:/Master");
    }

    // Update is called once per frame
    void Update()
    {
        Music.setVolume(MusicVolume);
        SFX.setVolume(SFXVolume);
        Master.setVolume(MasterVolume);
    }
}
