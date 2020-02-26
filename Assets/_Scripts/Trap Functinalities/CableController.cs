using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableController : MonoBehaviour
{

    [HideInInspector]
    public bool trapActive;

    private void Awake()
    {
        trapActive = true;
        
    }

    private void Update()
    {
        if (trapActive = false)
        {
            //GetComponentInChildren<ElectricCableTrap>();
        }
    }
}
