using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseScript : MonoBehaviour
{
    //game and player states variables !
    public GameStates gameStates;
    public PlayerStatesMovements playerstatesA;
    public float eatTime = 2f;
    //checking if the cheese is triggred by the player
    bool istrigger;
    //checking if it has been triggred more than once !
    bool moreThanOnce;
    //amount of score given!
    public int scoreGiven = 0;

    [HideInInspector] public GameObject target;


    private void OnTriggerStay(Collider other)
    {
        //detecting the collision with the player !
        if (other.CompareTag("Player"))
        {
            target = other.gameObject;
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
                    //adding 5 points to the score !
                    gameStates.AddScorePoints(5);
                    //the amount of score added!
                    scoreGiven = gameStates.scoreadded;
                    //checking if the score is more than the highscore to update it
                    gameStates.newHighScore();
                    istrigger = false;
                }
                playerstatesA.isEating = true;
                //eatTime = 2.5f;
                Destroy(transform.parent.gameObject, eatTime);
            }else if (this.gameObject.CompareTag("mediumCheese"))
            {
                //checking ifthe player collided with that type of cheese !
                if (istrigger == true)
                {
                    moreThanOnce = true;
                    //adding 6 points to the score !
                    gameStates.AddScorePoints(15);
                    //the amount of score added!
                    scoreGiven = gameStates.scoreadded;
                    //checking if the score is more than the highscore to update it
                    gameStates.newHighScore();
                    istrigger = false;
                }
                playerstatesA.isEating = true;
                //eatTime = 5;
                Destroy(transform.parent.gameObject, eatTime);
            }
            else if (this.gameObject.CompareTag("largeCheese"))
            {
                //checking ifthe player collided with that type of cheese !
                if (istrigger == true)
                {
                    moreThanOnce = true;
                    //adding 9 points to the score !
                    gameStates.AddScorePoints(gameStates.score);
                    //the amount of score added!
                    scoreGiven = gameStates.scoreadded;
                    //checking if the score is more than the highscore to update it
                    gameStates.newHighScore();
                    istrigger = false;
                }
               
                playerstatesA.isEating = true;
                //eatTime = 7.5f;
                Destroy(transform.parent.gameObject, eatTime);
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
