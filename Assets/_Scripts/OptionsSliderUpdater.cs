using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsSliderUpdater : MonoBehaviour
{

    //Reference to the music manager
    public GameObject MM;
    
    //Volume slider
    public Slider MusicSlider;
    public Slider SFXSlider;
    public Slider MasterSlider;
    
    // Start is called before the first frame update
    void Start()
    {
        MM = GameObject.FindGameObjectWithTag("musicManager");

        MusicSlider.value = MM.GetComponent<AudioSettings>().MusicVolume;
        SFXSlider.value = MM.GetComponent<AudioSettings>().SFXVolume;
        MasterSlider.value = MM.GetComponent<AudioSettings>().MasterVolume;

        //MusicSlider.value = MusicVolume;
        //SFXSlider.value = SFXVolume;
        //MasterSlider.value = MasterVolume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
