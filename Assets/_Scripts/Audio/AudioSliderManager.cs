using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSliderManager : MonoBehaviour
{
    public Slider musicSlider;
    public Slider SFXSlider;
    public Slider MasterSlider;

    // Start is called before the first frame update
    void Start()
    {
        musicSlider.value = AudioManager.MusicVolume;
        SFXSlider.value = AudioManager.SFXVolume;
        MasterSlider.value = AudioManager.MasterVolume;

        MasterSlider.value = PlayerPrefs.GetFloat("Master");
        SFXSlider.value = PlayerPrefs.GetFloat("SFX");
        musicSlider.value = PlayerPrefs.GetFloat("Music");
    }

    public void ChangeMaster()
    {
        AudioManager.MasterVolume = MasterSlider.value;
        PlayerPrefs.SetFloat("Master", AudioManager.MasterVolume);
    }

    public void ChangeSFX()
    {
        AudioManager.SFXVolume = SFXSlider.value;
        PlayerPrefs.SetFloat("SFX", AudioManager.SFXVolume);
    }

    public void ChangeMusic()
    {
        AudioManager.MusicVolume = musicSlider.value;
        PlayerPrefs.SetFloat("Music", AudioManager.MusicVolume);
    }
}
