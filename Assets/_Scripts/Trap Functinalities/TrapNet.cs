using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapNet : MonoBehaviour
{
    
    //public
    public GameObject trapNet;
    public GameObject cutTrapnet;

    //private
    
    //-------------------------------------------------------

    private void OnTriggerEnter(Collider other)
    {
        trapNet.GetComponent<Rigidbody>().useGravity = true;
        print("cool");
    }
    
    
    
}
