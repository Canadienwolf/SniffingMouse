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
    public PlayerStatesMovements psm;
    
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
            else 
            {
                if ((other.GetComponent<PickupSystem>().pickableObject.GetComponent<SharpOrHeavy>().type == SharpOrHeavy.Type.Heavy && GetComponent<DestructibleObject>().heavy) || 
                    (other.GetComponent<PickupSystem>().pickableObject.GetComponent<SharpOrHeavy>().type == SharpOrHeavy.Type.Sharp && GetComponent<DestructibleObject>().sharp))
                {
                    return;
                }
                else
                {
                    StartCatch(other.gameObject);
                }
            }
        }
    }

    void StartCatch(GameObject player)
    {
        player.GetComponent<MoveBehavior>().enabled = false;
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
            endMessage = "You drowned!";
        }
        else if(this.gameObject.transform.parent.name == "TrapCage_v01")
        {
            DeathScreensScript.sprite = 9;
            endMessage = "Put behind bars!";
        }
        else
        {
            DeathScreensScript.sprite = 5;
            endMessage = "You got caught!";

        }

        gameStatesA.EndGame(endMessage, lostScore);
        //SceneManager.LoadScene("menu_ScoreDisplay", LoadSceneMode.Single);

    }
}
