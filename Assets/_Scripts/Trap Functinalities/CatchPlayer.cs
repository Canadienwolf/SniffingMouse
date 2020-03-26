﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CatchPlayer : MonoBehaviour
{
    public float endTime = 3;
    public string endMessage = "You died";
    public int lostScore = 0;
    //always declare a gamestates in order to use score functions/endgame method !
    public GameStates gameStatesA;
    public GameObject virtualCam;

    private void Start()
    {
        if (virtualCam != null) virtualCam.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.GetComponent<PickupSystem>().pickableObject == null)
            {
                if (virtualCam != null) virtualCam.SetActive(true);
                Invoke("Catch", endTime);
            }
            else if(other.GetComponent<PickupSystem>().pickableObject.GetComponent<SharpOrHeavy>() == null)
            {
                if(virtualCam != null) virtualCam.SetActive(true);
                Invoke("Catch", endTime);

            }
        }
    }

    void Catch()
    {
        gameStatesA.EndGame(endMessage, lostScore);
    }
}
