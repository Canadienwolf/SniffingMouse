using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMangerScript : MonoBehaviour
{
    //game and player states variables!
    public GameStates gameStates;
    public PlayerStatesMovements playerStatesMov;
    //player feedback texts !
    public Text timerText;
    public Text scoreText;
    public Text highScoreText;
  //  public Text gameOver;
  //  public Text prevScore;
    // public Text badSmellText;
    //cheese conter for the cheese available in the scene !
    int cheeseCounter;
    float help=0;
    //just if we want to display the previous score reached!
    int previousScore;

    //use this one !
    public static int score;
    //use this one !
    public static string endMsg;
    //current scene name!
    public static string sceneName;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        // start the game !
        Time.timeScale = 1;
        //countig how many cheese objects are  in the scene !
        cheeseCounter = GameObject.FindGameObjectsWithTag("Cheese").Length;
        //gameOver.gameObject.SetActive(false);
        //badSmellText.gameObject.SetActive(false);
       // gameOver.text = " Time Limit Reached ! Game Over !";
        // get in the last highscore for that specific scene that we are in at the moment !
        gameStates.highScore = PlayerPrefs.GetInt("Highscore" + SceneManager.GetActiveScene().buildIndex.ToString(), 0);
        //updating the game/player states important variables !
        gameStates.score = 0;
        gameStates.timer = 120f;
        gameStates.scoreadded = 0;
        gameStates.scorelost = 0;
        //loading and displaying the previous score on the current level !
        previousScore = PlayerPrefs.GetInt("PreviousScore" + SceneManager.GetActiveScene().buildIndex.ToString(),0);
       // prevScore.text = "Previous Score : " + previousScore.ToString();

        //setting the score to 0!
        score = 0;
        //getting the current scene name!
        sceneName = SceneManager.GetActiveScene().name;
        //getting the current scene name!
        endMsg = null;
    }

    // Update is called once per frame
    void Update()
    {

        //updating the score !
        score = gameStates.score;
        //Updating Ui feedback for the player !
        if(scoreText != null)
            scoreText.text = "Score : " + gameStates.score.ToString();
        if(highScoreText != null)
            highScoreText.text = "HighScore : " + gameStates.highScore.ToString();

        //the public timer from the gamestates !
        if(timerText != null)
            timerText.text = "Timer : " + gameStates.timer.ToString("f0");

        //timer method !
        gameStates.TimeFlies();

       // Debug.Log("timer: " + gameStates.timer + "\n");
        //Debug.Log("help: " + help + "\n");

        //calling that public local method when the player lose !
        //LoseMethod();


        //calling that public local method when the player win !
        //WinMethod();

        //new highscore check !
        gameStates.newHighScore();

    }
    //just for the gameManger
    public void LoseMethod()
    {
        if (gameStates.timer <= 0)
        {
            //setting the timer to 0 when it's reached !
            gameStates.timer = 0;
            //saving the score in that current level you're in in order to display it later on !
            PlayerPrefs.SetInt("PreviousScore" + SceneManager.GetActiveScene().buildIndex.ToString(), gameStates.score);
            //interrupt the game 
            Time.timeScale = 0;
            EndGame("Time Passed , You Lost !", 0);

        }
    }
    //just for the gameManger
    public void WinMethod()
    {
        if (cheeseCounter == 0)
        {

            //saving the score in that current level you're in in order to display it later on !
            PlayerPrefs.SetInt("PreviousScore" + SceneManager.GetActiveScene().buildIndex.ToString(), gameStates.score);
            //interrupt the game 
            Time.timeScale = 0;
            EndGame("Congratulations , you won !", 0);
        }
    }

    //method to call for the win/loss event!
    public static void EndGame(string message,int scorePoints)
    {
        endMsg = message;
        score += scorePoints;
        if (score < 0)
        {
            score = 0;

        }
        //loading the loss/win menu !
        SceneManager.LoadScene("menu_ScoreDisplay");
    }

    //onApplicationQuit
    private void OnApplicationQuit()
    {
        //saving the score in that current level you're in in order to display it later on !
        PlayerPrefs.SetInt("PreviousScore" + SceneManager.GetActiveScene().buildIndex.ToString(), gameStates.score);
        //need to test that line of code later ! (just for saving the current highscore for the current level !)
        PlayerPrefs.SetInt("Highscore" + SceneManager.GetActiveScene().buildIndex.ToString(), gameStates.highScore);
        //updating the game/player states important variables !
        gameStates.score = 0;
        gameStates.timer = 300f;
        gameStates.scoreadded = 0;
        gameStates.scorelost = 0;
        playerStatesMov.lockController = false;
        

    }
}
