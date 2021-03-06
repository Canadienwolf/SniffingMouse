﻿using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrapDetection : MonoBehaviour
{
    public PlayerStatesMovements playerStatesA;
    public GameObject cheese;
    Animator anim;
    public GameStates gamestatesA;
    //checking if it has been triggered more than once !
    bool moreThanOnce;
    //checking if the cheese is triggered by the player
    bool istrigger = true;
    private bool activated;
    
    //.....................SFX.........................
    [FMODUnity.EventRef]
    public string SmackSoundEvent = "";
    
    // Start is called before the first frame update
    void Start()
    {
        //getting the animator that's on the trap !
        anim = this.gameObject.GetComponent<Animator>();
        EnableDisableCols(false);
        cheese.transform.GetChild(0).gameObject.GetComponent<SphereCollider>().enabled = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        //Detecting collision with player
        if (other.gameObject.CompareTag("Player"))
        {
           
            //checking if the player collided with that type of cheese !
            if (istrigger == true)
            {
                if (moreThanOnce == false)
                {
                    moreThanOnce = true;
                    //calling the losing event (menu)!
                    other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    FindObjectOfType<DeathMusic>().dying = true;
                    Invoke("Transition", 1.4f);
                    Invoke("Die", 2);
                    Invoke("SFXSmack", 0.3f);
                    //Die();

                }

            }
            //activating the animation
            anim.Play("apim_SpringLoaded_Trap");
            if (!activated)
            {
                //locking the player controlls
                playerStatesA.lockController = true;
                playerStatesA.isEating = false;
                
            }
           
        }
        if (other.tag == "Pickable")
        {
            anim.Play("apim_SpringLoaded_Trap");
            activated = true;
            cheese.transform.GetChild(0).gameObject.GetComponent<SphereCollider>().enabled = true;
            EnableDisableCols(true);
            GetComponent<SphereCollider>().enabled = false;
        }
    }
 

    void EnableDisableCols(bool idx)
    {
        foreach (Collider c in cheese.GetComponents<Collider>())
        {
            c.enabled = idx;
        }
    }

    void Transition()
    {
        GameObject.Find("SceneTransition").GetComponent<Animator>().SetTrigger("EndLevel");
    }

    //calling the losing event!
    void Die()
    {
        DeathScreensScript.sprite = 10;
        //loading the loss/win menu !
        gamestatesA.EndGame("You got split!", (-15));
      
    }

    private void OnApplicationQuit()
    {
        //updating the player state lock controller before quit !
        playerStatesA.lockController = false;
    }

    private void SFXSmack()
    {
        
        FMODUnity.RuntimeManager.PlayOneShot(SmackSoundEvent);

    }
}
