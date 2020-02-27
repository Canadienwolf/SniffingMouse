﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_GroundCheck : MonoBehaviour
{
    public PlayerStatesMovements psm;
    public bool isGrounded;
    public bool justHit;

    private void Update()
    {
        psm.isGrounded = isGrounded;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" && other.tag != "Pickable" && !other.GetComponent<Collider>().isTrigger)
        {
            isGrounded = true;
            justHit = true;
            Invoke("StopJusthit", 0.25f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "Player" && other.tag != "Pickable" && !other.GetComponent<Collider>().isTrigger)
            isGrounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player" && other.tag != "Pickable" && !other.GetComponent<Collider>().isTrigger)
            isGrounded = false;
    }

    void StopJusthit()
    {
        justHit = false;
    }
}
