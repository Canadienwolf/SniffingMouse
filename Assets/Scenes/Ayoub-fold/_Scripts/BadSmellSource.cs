using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BadSmellSource : MonoBehaviour
{
    public GameStates gamestatesA;
    public PlayerStatesMovements playerStatesA;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerStatesA.isMoving = false;
            // Debug.Log("entered!");
            //calling the loss event !
            //Die();
            GameMangerScript.EndGame("You lost !",-3);
        }
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
