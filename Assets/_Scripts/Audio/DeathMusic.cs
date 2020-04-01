using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMusic : MonoBehaviour
{

    [FMODUnity.EventRef]
    public string DeathEvent = "";
    
    
    public bool dying = false;
    public bool hasplayed = false;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dying && hasplayed == false)
        {
            GameObject.FindGameObjectWithTag("musicManager").SetActive(false);
            print("are you dying?");
            FMODUnity.RuntimeManager.PlayOneShot(DeathEvent);
            dying = false;
            hasplayed = true;
        }
    }
}
