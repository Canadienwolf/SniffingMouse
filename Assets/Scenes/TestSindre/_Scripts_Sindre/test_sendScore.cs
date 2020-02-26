using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class test_sendScore : test_timeAndScore
{
    public int seconds;
    public int min;
    void Start()
    {
        score = 0;
        InvokeRepeating("CountDown", 1, 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "smallCheese")
        {
            score += 2;
        }

        if (other.tag == "mediumCheese")
        {
            score += 5;
        }

        if (other.tag == "largeCheese")
        {
            score *= 2;
        }
    }

    void CountDown()
    {
        seconds--;
        if (seconds == -1)
        {
            seconds = 59;
            min--;
        }

        if (min == 0 && seconds == 0)
        {
            SceneManager.LoadScene("menu_ScoreDisplay", LoadSceneMode.Single);
        }
    }
}
