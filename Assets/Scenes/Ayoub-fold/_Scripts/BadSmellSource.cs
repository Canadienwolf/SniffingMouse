using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BadSmellSource : MonoBehaviour
{
    public GameStates gamestatesA;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           // Debug.Log("entered!");
           //calling the loss event !
            Die();
        }
    }

    void Die()
    {
        //saving the score in that current level you're in in order to display it later on !
        PlayerPrefs.SetInt("PreviousScore" + SceneManager.GetActiveScene().buildIndex.ToString(), gamestatesA.score);
        //saving the score in that current level you're in in order to display it later on !
        PlayerPrefs.SetInt("Highscore" + SceneManager.GetActiveScene().buildIndex.ToString(), gamestatesA.highScore);
        //loading the loss/win menu !
        SceneManager.LoadScene("menu_ScoreDisplay");
    }
}
