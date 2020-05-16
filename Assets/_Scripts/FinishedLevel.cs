using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/* SUBSCRIBING TO MY YOUTUBE CHANNEL: 'VIN CODES' WILL HELP WITH MORE VIDEOS AND CODE SHARING IN THE FUTURE :) THANK YOU */

public class FinishedLevel : MonoBehaviour
{
    public static int nextSceneLoad;
    public float endTime = 0.7f;
    public GameStates gameStatesA;

    // Start is called before the first frame update
    void Start()
    {
        gameStatesA.won = false;
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameStatesA.won = true;
            if (SceneManager.GetActiveScene().buildIndex == 10) /* < we will Change this int value to whatever we want when we have more 
                                                                  levels  */
            {
                Debug.Log("You Completed ALL Levels");//small check

                
            }
            else
            {
                 //Setting Int for Index
                if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
                {
                    PlayerPrefs.SetInt("levelAt", nextSceneLoad);
                }
               
            }

            StartCatch(other.gameObject);
        }
    }

    void StartCatch(GameObject player)
    {
        player.GetComponent<test_PlayerMovement03>().psm.lockController = true;
        Invoke("Transition", endTime - .6f);
        Invoke("Catch", endTime);
    }

    void Transition()
    {
        GameObject.Find("SceneTransition").GetComponent<Animator>().SetTrigger("EndLevel");
    }

    void Catch()
    {
       
        gameStatesA.EndGame("You finished the level!", 0);
    }
}
