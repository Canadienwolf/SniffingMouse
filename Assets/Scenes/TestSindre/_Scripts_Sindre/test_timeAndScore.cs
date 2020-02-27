using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class test_timeAndScore : MonoBehaviour
{
    static public int score;
    static public int highScore;

    public Text txt;

    private void Start()
    {
        if (score > highScore)
            highScore = score;

        if (txt != null)
            txt.text = "HighScore:" + highScore + "\n Time: 5:00";
    }
}
