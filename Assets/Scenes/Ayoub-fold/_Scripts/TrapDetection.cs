using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrapDetection : MonoBehaviour
{
    public PlayerStatesMovements playerStatesA;
    Animator anim;
    
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
            //locking the player controlls
            playerStatesA.lockController = true;
            //activating the animation
            anim.Play("apim_SpringLoaded_Trap");
            //calling the losing event (menu)!
            Invoke("Die", 2);

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
