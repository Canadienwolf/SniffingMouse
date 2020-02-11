using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmellDetectionScript : MonoBehaviour
{
    //variables needed !
    public Text gameOverText;
    public static bool help=false;
    bool istrigred;
    public PlayerStatesMovements playerStatesB;
    public GameStates gameStates;
    float step;
    bool isOutside;
    float helpTimer;
    

    public float frequency = 16f; // Speed of sine movement !
    public float magnitude = 2f; // Size of sine movement

    private void Update()
    {
     
       //if the player collides with the bad smell !
        if (istrigred == true)
        {
           //moving the player to the source of the smeel with drunk behaviour ! ( we have the variables as public now so we can change the values in inspector!
           GameObject.FindGameObjectWithTag("Player").transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + transform.forward * Mathf.Sin(Time.time * frequency) * magnitude;
        }

        //testing if the player is not colliding with the bad smell anymore !
        if (isOutside)
        {
            //drunkness movement for the player !
            GameObject.FindGameObjectWithTag("Player").transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + transform.forward * Mathf.Sin(Time.time * frequency) * magnitude;
            if (gameStates.timer <= helpTimer)
            {
                //for sttoping the drunkness movments !
                isOutside = false;
            }
        }

    }

    //for detecting the collisions triggered !
    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            help = true;
            istrigred = true;
            //movTimer = (int)(gameStates.timer - 10f);
            Debug.Log("he is triggered");

        }
 
    }
    private void OnTriggerExit(Collider other)
    {
        //updating the variables after the collision finishes !
        istrigred = false;
        help = false;
        isOutside = true;
        //for stopping the drunkness afterward !
        helpTimer = (gameStates.timer) - 5;

    }
    private void OnApplicationQuit()
    {
        //updating the variables after quitig the game !
        help = false;
        playerStatesB.lockController = false;
    }

}
