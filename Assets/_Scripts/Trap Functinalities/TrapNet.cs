using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapNet : MonoBehaviour
{
    
    //public
    [Range(0, 100)]
    public float speed;
    
    [HideInInspector]
    public GameObject trapNet;
    public GameObject cutTrapnet;

    //private
    private GameObject triggerButton;
    private bool triggerActive;
    
    //-------------------------------------------------------

    private void Start()
    {
        triggerButton = gameObject;
    }

    private void Update()
    {
        if (triggerActive && trapNet != null)
        {
            trapNet.transform.position = Vector3.MoveTowards(trapNet.transform.position, triggerButton.transform.position, Time.deltaTime * speed);
        }

        if (trapNet == null)
        {
            cutTrapnet.SetActive(true);
            cutTrapnet.transform.position = trapNet.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        triggerActive = true;
    }
}
