using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
    public GameStates gs;
    public Text header;
    public Text score;
    public Text highscore;

    // Start is called before the first frame update
    void Start()
    {
        if(header != null)
            header.text = GameMangerScript.endMsg;
        if(score != null)
            score.text = GameMangerScript.score + "";
        if(highscore != null)
            highscore.text = gs.highScore + "";
    }
}
