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
    public bool freezePlayer;
    
    //-------------------------------------------SFX-------------------
    public GameObject SFX;
    //--------------------------------------

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
                StartCatch(other.gameObject);
            }
            else if(other.GetComponent<PickupSystem>().pickableObject.GetComponent<SharpOrHeavy>() == null)
            {
                StartCatch(other.gameObject);
            }
        }
    }

    void StartCatch(GameObject player)
    {
        if (freezePlayer) player.GetComponent<test_PlayerMovement03>().psm.lockController = true;
        if (virtualCam != null) virtualCam.SetActive(true);
        FindObjectOfType<DeathMusic>().dying = true;
        if(SFX != null)
            SFX.SetActive(true);
        Invoke("Transition", endTime - .6f);
        Invoke("Catch", endTime);
    }

    void Transition()
    {
        GameObject.Find("SceneTransition").GetComponent<Animator>().SetTrigger("EndLevel");
    }

    void Catch()
    {
        if (this.gameObject.transform.parent.name == "Bucket")
        {
            DeathScreensScript.sprite = 6;
            endMessage = "You drowned";
        }
        else if(this.gameObject.transform.parent.name == "TrapCage_v01")
        {
            DeathScreensScript.sprite = 9;
            endMessage = "You got caged";
        }
        else
        {
            DeathScreensScript.sprite = 5;
            endMessage = "You got catched";

        }

        gameStatesA.EndGame(endMessage, lostScore);
        SceneManager.LoadScene("menu_ScoreDisplay", LoadSceneMode.Single);

    }
}
