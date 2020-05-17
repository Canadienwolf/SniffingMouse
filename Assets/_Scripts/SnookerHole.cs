using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnookerHole : MonoBehaviour
{
    public delegate void OnNewBall();
    public static event OnNewBall onNewBall;

    private void OnTriggerEnter(Collider other)
    {
        SnookerBall snookerBall = other.GetComponent<SnookerBall>();
        if (snookerBall != null)
        {
            onNewBall();
        }
    }
}
