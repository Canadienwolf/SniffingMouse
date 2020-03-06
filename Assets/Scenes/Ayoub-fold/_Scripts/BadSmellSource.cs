using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BadSmellSource : MonoBehaviour
{
    public GameStates gamestatesA;
    public PlayerStatesMovements playerStatesA;
    public float deathTime = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerStatesA.isMoving = false;
            playerStatesA.lockController = true;
            // Debug.Log("entered!");
            //calling the loss event !
            //Die();
            Invoke("End", deathTime);
        }
    }

    void End()
    {
        GameMangerScript.EndGame("That was too stinky", -3);
    }

    /* void Die()
     {
         //saving the score in that current level you're in in order to display it later on !
         PlayerPrefs.SetInt("PreviousScore" + SceneManager.GetActiveScene().buildIndex.ToString(), gamestatesA.score);
         //saving the score in that current level you're in in order to display it later on !
         PlayerPrefs.SetInt("Highscore" + SceneManager.GetActiveScene().buildIndex.ToString(), gamestatesA.highScore);
         //loading the loss/win menu !
         SceneManager.LoadScene("menu_ScoreDisplay");
     }*/
}
