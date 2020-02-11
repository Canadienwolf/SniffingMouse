using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMangerScript : MonoBehaviour
{
    public GameStates gameStates;
    public PlayerStatesMovements playerStatesMov;
    //player feedback texts !
    public Text timerText;
    public Text scoreText;
    public Text highScoreText;
    public Text gameOver;
   // public Text badSmellText;
    int cheeseCounter;
    float help=0;

    // Start is called before the first frame update
    void Start()
    {
        // start the game !
        Time.timeScale = 1;
        cheeseCounter = GameObject.FindGameObjectsWithTag("Cheese").Length;
        gameOver.gameObject.SetActive(false);
        //badSmellText.gameObject.SetActive(false);
        gameOver.text = " Time Limit Reached ! Game Over !";
    }

    // Update is called once per frame
    void Update()
    {
        
        scoreText.text = "Score : " + gameStates.score.ToString();
        highScoreText.text = "HighScore : " + gameStates.highScore.ToString();
        timerText.text = "Timer : " + gameStates.timer.ToString("f0");

        //timer method !
        gameStates.TimeFlies();

       // Debug.Log("timer: " + gameStates.timer + "\n");
        Debug.Log("help: " + help + "\n");

        //calling that public local method when the player lose !
        LoseMethod();


        //calling that public local method when the player win !
        WinMethod();

        /////////////////******* will work on the feedback later on *********///////////////
        //detecting the interaction with the bad smell
      /*  if (SmellDetectionScript.help == true)
        {
            help = gameStates.timer;
            badSmellText.text = "BBBrrr , no a Bad Smell !";
            badSmellText.gameObject.SetActive(true);
            SmellDetectionScript.help = false;
        }
        if ((int)gameStates.timer == ((int)help - 3))
        {

            //badSmellText.gameObject.SetActive(false);
        }*/

    }

    public void LoseMethod()
    {
        if (gameStates.timer <= 0)
        {
            //setting the timer to 0 when it's reached !
            gameStates.timer = 0;
            //gameover text !
            gameOver.gameObject.SetActive(true);
            //interrupt the game 
            Time.timeScale = 0;
            //calling the loss/win menu
            SceneManager.LoadScene("menu_ScoreDisplay");

        }
    }

    public void WinMethod()
    {
        if (cheeseCounter == 0)
        {
            //text for congrats to the player !
            gameOver.text = " Congratulations , you won !";
            gameOver.gameObject.SetActive(true);
            //interrupt the game 
            Time.timeScale = 0;
            //calling the loss/win menu
            SceneManager.LoadScene("menu_ScoreDisplay");
        }
    }

    //onApplicationQuit
    private void OnApplicationQuit()
    {
        //updating the game/player states important variables !
        gameStates.score = 0;
        gameStates.timer = 120f;
        playerStatesMov.lockController = false;
        
    }
}
