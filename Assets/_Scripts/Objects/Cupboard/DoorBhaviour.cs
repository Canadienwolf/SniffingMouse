using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBhaviour : MonoBehaviour
{

    public Animator doorAnimation;

    private bool opened = false;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider Player)
    {
        if (Input.GetKey(KeyCode.E) && opened == false)
        {
            doorAnimation.SetTrigger("Open");
            opened = true; 
        }
        
    }
}
