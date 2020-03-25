using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "New GameST ", menuName = "Game States ")]
public class GameStates : ScriptableObject
{
    //The timer ( need to be assigned a value later on ! )
    public float timer=120f;

    //Current score
    public int score=0;
    //just to know how many scorepoints lost
    public int scorelost = 0;
    //just to know how many scorepoints added
    public int scoreadded = 0;

    //The highscore used for the game !
    public int highScore=0;

    public string endMsg;

    //Highscore handling function !
    public void newHighScore()
    {
        if (score >= highScore)
        {
            //updating the highscore!
             highScore = score;
         
        }
    }

    //adding score points function !
    public void AddScorePoints(int points)
    {
        //incrementing the score by 5 for every cheese , then adding more on the cheese script depending on the type of cheese!
        score += points;
        //counting how many score points are gained !
        scoreadded = points;
       
    }

    //losing score point function !
    public void LoseScorePoints(int points)
    {
        //decreasing the score by 3 when we want the player to lose some score points !
        score -= points;
        if (score < 0)
        {
            score = 0;
        }
        //counting how many score points are lost !
        scorelost = points;
      

    }

    //method to call for the win/loss event!
    public void EndGame(string message, int scorePoints)
    {
        endMsg = message;
        score += scorePoints;
        SceneManager.LoadScene("menu_ScoreDisplay");

    }


    //must be called in the update later on !
    public void TimeFlies()
    {
        timer -= Time.deltaTime;
    }
}
