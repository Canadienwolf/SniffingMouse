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
    public static int highScore;

    // Start is called before the first frame update
    void Start()
    {
        //for test !
        //Debug.Log("score :" + GameMangerScript.score);
        if(header != null)
            header.text = gs.endMsg;
        if(score != null)
            score.text = gs.score + "";
        if(highscore != null)
            highscore.text = highScore + "";
        //highscore.text = gs.highScore + "";
    }
   
}
