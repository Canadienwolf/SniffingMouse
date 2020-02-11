using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseScript : MonoBehaviour
{
    //game and player states variables !
    public GameStates gameStates;
    public PlayerStatesMovements playerstatesA;
    //checking if the cheese is triggred by the player
    bool istrigger;
    //checking if it has been triggred more than once !
    bool moreThanOnce;


    private void OnTriggerStay(Collider other)
    {
        //detecting the collision with the player !
        if (other.CompareTag("Player"))
        {
            //checking if is the 1 collision with the player or not !
            if (moreThanOnce == false)
            {
                istrigger = true;
            }
            
            //feedback updates for the player !
            playerstatesA.lockController = true;

            //destroying the particl system on the cheese first!
            //Destroy(transform.parent.GetChild(1).gameObject);

            //for detecting which kind of cheese !!
            if (this.gameObject.CompareTag("smallCheese"))
            {
                //checking ifthe player collided with that type of cheese !
                if (istrigger == true)
                {
                    moreThanOnce = true;
                    gameStates.AddScorePoints();
                    gameStates.score += 2;
                    gameStates.newHighScore();
                    istrigger = false;
                }
                playerstatesA.isEating = true;
                Destroy(transform.parent.gameObject, 2.5f);
            }else if (this.gameObject.CompareTag("mediumCheese"))
            {
                //checking ifthe player collided with that type of cheese !
                if (istrigger == true)
                {
                    moreThanOnce = true;
                    gameStates.AddScorePoints();
                    gameStates.score += 3;
                    gameStates.newHighScore();
                    istrigger = false;
                }
                playerstatesA.isEating = true;
                Destroy(transform.parent.gameObject, 5);
            }
            else if (this.gameObject.CompareTag("largeCheese"))
            {
                //checking ifthe player collided with that type of cheese !
                if (istrigger == true)
                {
                    moreThanOnce = true;
                    gameStates.AddScorePoints();
                    gameStates.score += 5;
                    gameStates.newHighScore();
                    istrigger = false;
                }
               
                playerstatesA.isEating = true;
                Destroy(transform.parent.gameObject, 7.5f);
            }
        }
        
    }

    private void OnDestroy()
    {
        //Updating the necessary variables after destroying the cheese !
        playerstatesA.lockController = false;
        playerstatesA.isEating = false;
        moreThanOnce = false;
    }

}
