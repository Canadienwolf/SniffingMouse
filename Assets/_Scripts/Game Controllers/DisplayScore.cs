using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
    public GameStates gs;
    public Text txt;

    // Start is called before the first frame update
    void Start()
    {
        txt.text = "Time: " + gs.timer + "\n Your Score: " + gs.score + "\n Highscore: " + gs.highScore;
    }
}
