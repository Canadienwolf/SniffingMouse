using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastLevelCheck : MonoBehaviour
{
    public GameObject nextButton;

    // Update is called once per frame
    void Update()
    {
        if (FinishedLevel.nextSceneLoad > 6) /* < we will Change this int value to whatever we want when we have more 
                                                                  levels  */
        {
            Debug.Log("You Completed ALL Levels");

            //Calling the level selections scene when the player finishes all the level.
            // SceneManager.LoadScene("Level Selections");
            nextButton.SetActive(false);
        }
        else
        {
            nextButton.SetActive(true);
        }
    }
}
