using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    [FMODUnity.EventRef] 
    public string inputSound;
    public float walkingSpeed;
    
    private bool _playerIsMoving;

    private void Update()
    {
        if (Input.GetAxis("Vertical") >= 0.01f || Input.GetAxis("Horizontal") >= 0.01f || Input.GetAxis("Vertical") <= -0.01f || Input.GetAxis("Horizontal") <= -0.01f)
        {
            Debug.Log("Player is moving");
            _playerIsMoving = true;
        }
        
        else if (Input.GetAxis("Vertical") == 0 || Input.GetAxis("Horizontal") == 0)
        {
            Debug.Log("Player is not moving");
            _playerIsMoving = false;
        }
    }

    void CallFootsteps()
    {
        Debug.Log("Player is moving");
        FMODUnity.RuntimeManager.PlayOneShot(inputSound);
    }

    private void Start()
    {
        InvokeRepeating("CallFootsteps", 0, walkingSpeed);
    }

    private void OnDisable()
    {
        _playerIsMoving = false;
    }
}
