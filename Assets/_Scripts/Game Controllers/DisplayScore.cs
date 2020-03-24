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
        //for test !
        //Debug.Log("score :" + GameMangerScript.score);
        if(header != null)
            header.text = gs.endMsg;
        if(score != null)
            score.text = gs.score + "";
        //changed it in order to fix it after mid term !
        //score.text = GameMangerScript.score + "";
        if(highscore != null)
            highscore.text = gs.highScore + "";
    }
   
}
