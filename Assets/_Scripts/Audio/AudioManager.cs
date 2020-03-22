using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    FMOD.Studio.EventInstance SFXVolumeTestEvent;

    //Game Managers
    public AudioSettings GSAudioManager;
    
    //Fmod connections
    public FMOD.Studio.Bus Music;
    public FMOD.Studio.Bus SFX;
    public FMOD.Studio.Bus Master;
    
    //Volume controls
    public float MusicVolume;
    public float SFXVolume;
    public float MasterVolume;

    private void Awake()
    {
        Music = FMODUnity.RuntimeManager.GetBus("bus:/Master/Music");
        SFX = FMODUnity.RuntimeManager.GetBus("bus:/Master/SFX");
        Master = FMODUnity.RuntimeManager.GetBus("bus:/Master");

        MasterVolume = GSAudioManager.MasterVolume;
        MusicVolume = GSAudioManager.MusicVolume;
        SFXVolume = GSAudioManager.SFXVolume;
    }

    // Update is called once per frame
    void Update()
    {
        Music.setVolume(MusicVolume);
        SFX.setVolume(SFXVolume);
        Master.setVolume(MasterVolume);
    }
    
    public void MasterVolumeLevel (float newMasterVolume)
    {
        MasterVolume = newMasterVolume;
        PlayerPrefs.SetFloat("MasterVolume", MasterVolume);
    }

    public void MusicVolumeLevel (float newMusicVolume)
    {
        MusicVolume = newMusicVolume;
        PlayerPrefs.SetFloat("MusicVolume", MusicVolume);
    }

    public void SFXVolumeLevel (float newSFXVolume)
    {
        SFXVolume = newSFXVolume;
        PlayerPrefs.SetFloat("SFXVolume", SFXVolume);

        /*
        FMOD.Studio.PLAYBACK_STATE PbState;
        SFXVolumeTestEvent.getPlaybackState (out PbState);
        if (PbState != FMOD.Studio.PLAYBACK_STATE.PLAYING) 
        {
            SFXVolumeTestEvent.start ();
        }
        */
        
    }
}
