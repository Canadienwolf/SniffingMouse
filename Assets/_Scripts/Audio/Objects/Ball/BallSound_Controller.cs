using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSound_Controller : MonoBehaviour
{
    
    [FMODUnity.EventRef]
    public string DamageEvent = "";
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.transform.tag == "Ground")
        {
            FMODUnity.RuntimeManager.PlayOneShot(DamageEvent);
        }
    }
}
