using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnookerPuzzle : MonoBehaviour
{
    public GameObject cheese;

    int balls;

    void Start()
    {
        Invoke("LateStart", 0.15f);
    }

    void LateStart()
    {
        cheese.SetActive(false);
    }

    private void OnEnable()
    {
        SnookerHole.onNewBall += AddNewBall;
    }
    private void OnDisable()
    {
        SnookerHole.onNewBall -= AddNewBall;
    }

    void AddNewBall()
    {
        balls++;
        if (balls == 6)
        {
            cheese.SetActive(true);
        }
    }
}
