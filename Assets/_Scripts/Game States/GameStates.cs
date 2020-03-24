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
    //Current score
    public int scorelost = 0;
    //Current score
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
            //storing the new high score for each scene using playerprefs and scene index for its name !
           // PlayerPrefs.SetInt("Highscore" + SceneManager.GetActiveScene().buildIndex.ToString(), highScore);
        }
    }

    //adding score points function !
    public void AddScorePoints()
    {
        //incrementing the score by 5 for every cheese , then adding more on the cheese script depending on the type of cheese!
        score += 5;
        //counting how many score points are gained !
        scoreadded += 5;
       // GameMangerScript.score = score;
    }

    //losing score point function !
    public void LoseScorePoints()
    {
        //decreasing the score by 3 when we want the player to lose some score points !
        score -= 3;
        if (score < 0)
        {
            score = 0;
        }
        //counting how many score points are lost !
        scorelost -= 3;
        //GameMangerScript.score = score;

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
