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
    public float time = 120;
    //player feedback texts !
    public Text timerText;
    public Text scoreText;
    public Text highScoreText;
    //cheese conter for the cheese available in the scene !
    int cheeseCounter;
    float help=0;

    //use this one !
   // public static int score;
    //use this one !
    public static string endMsg;
    //current scene name!
    public static string sceneName;

    private void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);
        gameStates.timer = time;
    }

    // Start is called before the first frame update
    void Start()
    {

        // start the game !
        Time.timeScale = 1;
        //getting the current scene name!
        sceneName = SceneManager.GetActiveScene().name;
        //getting the current scene name!
        endMsg = null;
        //countig how many cheese objects are  in the scene !
        cheeseCounter = GameObject.FindGameObjectsWithTag("Cheese").Length;
        // get in the last highscore for that specific scene that we are in at the moment !
        //gameStates.highScore = PlayerPrefs.GetInt("Highscore" + SceneManager.GetActiveScene().buildIndex.ToString(), 0);
        gameStates.highScore = PlayerPrefs.GetInt("Highscore" + sceneName.ToString(), 0);
        //updating the game/player states important variables !
        gameStates.score = 0;
        gameStates.scoreadded = 0;
        gameStates.scorelost = 0;
        
      
    }

    // Update is called once per frame
    void Update()
    {
        
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

        //new highscore check !
        gameStates.newHighScore();

        //losing after the time passed out !
        //LoseMethod();

    }
    //just for the gameManger
    public void LoseMethod()
    {
        if (gameStates.timer <= 0)
        {
            //setting the timer to 0 when it's reached !
            gameStates.timer = 0;
            //interrupt the game 
            Time.timeScale = 0;
            gameStates.EndGame("Time Passed , You Lost !", 0);

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
            gameStates.EndGame("Congratulations , you won !", 0);
        }
    }


    

    private void OnDisable()
    {
        //in order to display the highscore before saving it in playerprefs and deleting it afterward!
        DisplayScore.highScore = gameStates.highScore;
        //need to test that line of code later ! (just for saving the current highscore for the current level !)
        PlayerPrefs.SetInt("Highscore" + sceneName.ToString(), gameStates.highScore);
        //reseting the gamestate highscore variable !
        gameStates.highScore = 0;
        //updating the game/player states important variables !
        //gameStates.score = 0;
        gameStates.timer = 300f;
        // gameStates.scoreadded = 0;
        // gameStates.scorelost = 0;
        playerStatesMov.lockController = false;
    }
}
