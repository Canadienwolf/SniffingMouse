using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{

    FMOD.Studio.EventInstance SFXVolumeTestEvent;

    public FMOD.Studio.Bus Music;
    public FMOD.Studio.Bus SFX;
    public FMOD.Studio.Bus Master;
    public float MusicVolume = 0.5f;
    public float SFXVolume = 0.5f;
    public float MasterVolume = 1f;

    void Awake ()
    {
        //SFXVolumeTestEvent = FMODUnity.RuntimeManager.CreateInstance ("event:/SFX/SFXVolumeTest");
        
        //Makes sure that the gameobject is not destroyed between scene changes
        DontDestroyOnLoad(gameObject);
        
        
        //Checks if there are more instances than one of the MusicManager gameobject and then destroys it
        if (GameObject.FindGameObjectsWithTag(gameObject.tag).Length > 1)
        {
            Destroy(gameObject);
        }
        
    }

    
    
    void Update () 
    {
        Music.setVolume (MusicVolume);
        SFX.setVolume (SFXVolume);
        Master.setVolume (MasterVolume);
    }

    public void MasterVolumeLevel (float newMasterVolume)
    {
        MasterVolume = newMasterVolume;
    }

    public void MusicVolumeLevel (float newMusicVolume)
    {
        MusicVolume = newMusicVolume;
    }

    public void SFXVolumeLevel (float newSFXVolume)
    {
        SFXVolume = newSFXVolume;

        
        FMOD.Studio.PLAYBACK_STATE PbState;
        SFXVolumeTestEvent.getPlaybackState (out PbState);
        if (PbState != FMOD.Studio.PLAYBACK_STATE.PLAYING) 
        {
            SFXVolumeTestEvent.start ();
        }
        
    }
}