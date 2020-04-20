using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBhaviour : MonoBehaviour
{

    public Animator doorAnimation;


    public int doorPosition;

    // Start is called before the first frame update
    void Start()
    {
        doorPosition = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            print("1");
            
            /*
            if (doorPosition == 2)
            {
                print("2");
                doorAnimation.SetTrigger("Close");
                doorPosition = 1;
            }
            */

            if (doorPosition == 1)
            {
                print("3");
                doorAnimation.SetTrigger("Open");
                doorPosition = 2;
            }
            
            
        }
    }
}
