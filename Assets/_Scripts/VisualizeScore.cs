using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class VisualizeScore : MonoBehaviour
{
    private Text txt;
    private int currentScore;
    private string displayText;
    private bool displaying;
    private byte alpha;
    //always declare a gamestates in order to use score functions/endgame method !
    public GameStates gameStatesA;

    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<Text>();
        currentScore = gameStatesA.score;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScore != gameStatesA.score)
        {
            Display();
            currentScore = gameStatesA.score;
        }

        if (displaying)
        {
            alpha = (byte)Mathf.MoveTowards(alpha, 255, Time.deltaTime * 100);
            txt.color += new Color32(0, 0, 0, alpha);
        }
    }

    void Display()
    {
        displaying = true;
        int difference = gameStatesA.score - currentScore;
        alpha = 0;
        if (currentScore < gameStatesA.score)
        {
            txt.text = "+" + difference;
            txt.color = new Color32(87, 195, 67, 0);
        }
        else
        {
            txt.text = "" + difference;
            txt.color = new Color32(195, 47, 53, 0);
        }

        Invoke("HideText", 2);
    }

    void HideText()
    {
        txt.text = "";
        displaying = false;
    }
}
