using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New GameST ", menuName = "Game States ")]
public class GameStatestest : ScriptableObject
{
    //The timer ( need to be assigned a value later on ! )
    public float timer = 90f;

    //Current score
    public int score=0;

    //The highscore ("needs to be assigned to playerprefs later on")
    public int highScore = 0;


    public void newHighScore()
    {
        if (score >= highScore)
        {
            highScore = score;
        }
    }

    public void AddScorePoints()
    {
        // waiting for more events to be implemented into the game in order to increase the score*

        //using temporarly that one

        score += 5;

    }

    //must be called in the update later on !
    public void TimeFlies()
    {
        timer -= Time.deltaTime;
    }
    
    
}
