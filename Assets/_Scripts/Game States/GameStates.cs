using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New GameST ", menuName = "Game States ")]
public class GameStates : ScriptableObject
{
    //The timer ( need to be assigned a value later on ! )
    public float timer=90f;

    //Current score
    public int score=0;

    //The highscore ("needs to be assigned to playerprefs later on")
    public int highScore=0;


    public void newHighScore()
    {
        if (score >= highScore)
        {
            highScore = score;
        }
    }

    public void AddScorePoints()
    {

        //incrementing the score by 3 for the small cheese , but in the cheese script i add more to the score based on the other kind of chees !
        score += 5;

    }

    //must be called in the update later on !
    public void TimeFlies()
    {
        timer -= Time.deltaTime;
    }
}
