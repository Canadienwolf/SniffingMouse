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
            //updating the highscore!
             highScore = score;
            //storing the new high score!
             PlayerPrefs.SetInt("Highscore", highScore);
        }
    }

    public void AddScorePoints()
    {
        //incrementing the score by 5 for every cheese , then adding more on the cheese script depending on the type of cheese!
        score += 5;

    }

    //must be called in the update later on !
    public void TimeFlies()
    {
        timer -= Time.deltaTime;
    }
}
