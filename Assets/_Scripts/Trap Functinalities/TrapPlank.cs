using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlank : MonoBehaviour
{
    
    //public
    public float speed;
    
    
    //private
    private GameObject trap;
    private Quaternion rotation1 = Quaternion.Euler(0, 0, 0);
    private Quaternion rotation2 = Quaternion.Euler(-85, 0, 0);
    private bool falling;
    
    // Start is called before the first frame update
    void Start()
    {
        trap = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (falling)
        {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, rotation2, Time.deltaTime * speed);
        }

        if (!falling)
        {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, rotation1, Time.deltaTime * speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            falling = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        falling = false;
    }
}
