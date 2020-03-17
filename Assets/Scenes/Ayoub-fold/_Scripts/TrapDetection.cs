using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrapDetection : MonoBehaviour
{
    public PlayerStatesMovements playerStatesA;
    public GameObject cheese;
    Animator anim;
    public GameStates gamestatesA;
    
    private bool activated;
    
    // Start is called before the first frame update
    void Start()
    {
        //getting the animator that's on the trap !
        anim = this.gameObject.GetComponent<Animator>();
        EnableDisableCols(false);
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
                playerStatesA.isEating = false;
                //calling the losing event (menu)!
                Invoke("Die", 2);
            }
        }
        if (other.tag == "Pickable")
        {
            anim.Play("apim_SpringLoaded_Trap");
            activated = true;
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

    //calling the losing event!
    void Die()
    {
        gamestatesA.score -= 15;
       /* if (gamestatesA.score < 0)
        {
            gamestatesA.score = 0;
        }*/
        //loading the loss/win menu !
        GameMangerScript.EndGame("You got crushed , and lost score points !", (-15));
      
    }

    private void OnApplicationQuit()
    {
        //updating the player state lock controller before quit !
        playerStatesA.lockController = false;
    }
}
