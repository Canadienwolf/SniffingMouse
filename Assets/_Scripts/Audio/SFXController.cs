﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    
    public GameObject SFX;
    
    private void OnTriggerEnter(Collider Pickable)
    {
        SFX.SetActive(true);
    }
}
