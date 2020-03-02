using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_CheeseCounter : MonoBehaviour
{
    public static int cheeseNum;

    private void OnEnable()
    {
        cheeseNum++;
    }

    private void OnDestroy()
    {
        cheeseNum--;
        if (cheeseNum <= 0)
        {
            GameMangerScript.EndGame("You found all the cheese", 0);
        }
    }

    private void OnApplicationQuit()
    {
        cheeseNum = 0;
    }
}
