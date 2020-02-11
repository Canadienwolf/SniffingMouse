using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseScript : MonoBehaviour
{
    
    public GameStates gameStates;
    public PlayerStatesMovements playerstatesA;


    private void OnTriggerEnter(Collider other)
    {
        //detecting the collision with the player !
        if (other.CompareTag("Player"))
        {
            //feedback updates for the player !
            gameStates.AddScorePoints();
            gameStates.newHighScore();
            playerstatesA.lockController = true;

            //destroying the particl system on the cheese first!
            //Destroy(transform.parent.GetChild(1).gameObject);

            //for detecting which kind of cheese !!
            if (this.gameObject.CompareTag("smallCheese"))
            {
                playerstatesA.isEating = true;
                Destroy(transform.parent.gameObject, 2.5f);
            }else if (this.gameObject.CompareTag("mediumCheese"))
            {
                gameStates.score += 2;
                playerstatesA.isEating = true;
                Destroy(transform.parent.gameObject, 5);
            }
            else if (this.gameObject.CompareTag("largeCheese"))
            {
                gameStates.score += 4;
                playerstatesA.isEating = true;
                Destroy(transform.parent.gameObject, 7.5f);
            }
        }
        
    }

    private void OnDestroy()
    {
        playerstatesA.lockController = false;
        playerstatesA.isEating = false;
    }

}
