using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    private FMOD.Studio.EventInstance SFXVolumeTestEvent;

    private FMOD.Studio.Bus _Music;
    private FMOD.Studio.Bus _SFX;
    private FMOD.Studio.Bus _Master;
    private float MusicVolume = 0.5f;
    private float SFXVolume = 0.5f;
    private float MasterVolume = 1f;

    private void Awake()
    {
        _Music = FMODUnity.RuntimeManager.GetBus("bus:/Master/Music");
        _SFX = FMODUnity.RuntimeManager.GetBus("bus:/Master/SFX");
        _Master = FMODUnity.RuntimeManager.GetBus("bus:/Master");
        SFXVolumeTestEvent = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/SFXVolumeTest");
    }
    // Update is called once per frame    
    void Update()
    {
        _Music.setVolume(MusicVolume);
        _SFX.setVolume(SFXVolume);
        _Master.setVolume(MasterVolume);
    }

    public void MasterVolumeLevel(float newMasterVolume)
    {
        MasterVolume = newMasterVolume;
    }

    public void MusicVolumeLevel(float newMusicVolume)
    {
        MusicVolume = newMusicVolume;
    }

    public void SFXVolumeLevel(float newSFXVolume)
    {
        SFXVolume = newSFXVolume;

        FMOD.Studio.PLAYBACK_STATE PbState;
        SFXVolumeTestEvent.getPlaybackState(out PbState);
        if (PbState != FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {
            SFXVolumeTestEvent.start();
        }
    }
}
