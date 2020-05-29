using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    //FMOD.Studio.EventInstance SFXVolumeTestEvent;

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

    //gameobjects that contatin the music that is to be palyed in levels
    public GameObject[] MusicPerLevel;
    private int _activeScene;
    private int _songIndex;

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
    private void OnEnable()
    {
        SceneManager.sceneLoaded += ChangeSong;
    }
    
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= ChangeSong;
    }

    void ChangeSong(Scene scene, LoadSceneMode mode)
    {
        _activeScene = SceneManager.GetActiveScene().buildIndex;
        
        for (int i = 0; i < MusicPerLevel.Length; i++)
        {
            MusicPerLevel[i].SetActive(false);
        }

        if (_activeScene == 0 || _activeScene == 1 || _activeScene == 12 || _activeScene == 13)
        {
            _songIndex = 0;
        }
        
        else
        {
            _songIndex = Random.Range(1, MusicPerLevel.Length);
        }

        MusicPerLevel[_songIndex].SetActive(true);
    }
}
