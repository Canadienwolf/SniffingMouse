using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrapDetection : MonoBehaviour
{
    public PlayerStatesMovements playerStatesA;
    Animator anim;

    private bool activated;
    
    // Start is called before the first frame update
    void Start()
    {
        //getting the animator that's on the trap !
        anim = this.gameObject.GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        //Detecting collision with player
        if (other.gameObject.CompareTag("Player"))
        {

            //activating the animation
            anim.Play("apim_SpringLoaded_Trap");
            if (!activated)
            {
                //locking the player controlls
                playerStatesA.lockController = true;
                //calling the losing event (menu)!
                Invoke("Die", 2);
            }
        }
        if (other.tag == "Pickable")
        {
            anim.Play("apim_SpringLoaded_Trap");
            activated = true;
        }
    }

    //calling the losing event!
    void Die()
    {
        //loading the loss/win menu !
        SceneManager.LoadScene("menu_ScoreDisplay");
    }

    private void OnApplicationQuit()
    {
        //updating the player state lock controller before quit !
        playerStatesA.lockController = false;
    }
}
