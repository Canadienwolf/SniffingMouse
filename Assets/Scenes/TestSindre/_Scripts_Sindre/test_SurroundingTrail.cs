using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_SurroundingTrail : MonoBehaviour
{
    public float raiseTime = 3f;
    public float speed = 5f;

    private Vector3 startPos;
    private float t;
    private bool raising;
    private float timeCounter;
    private float b;

    void Update()
    {
        timeCounter = Mathf.MoveTowards(timeCounter, 0, Time.deltaTime);
        if (timeCounter == 0)
        {
            timeCounter = raiseTime;
            raising = !raising;
        }

        t = raising ? Time.deltaTime * speed + t : Time.deltaTime * speed + t;
        b = raising ? 1 : -1;

        transform.localPosition = new Vector3(t * Mathf.Cos(t), 0, t * Mathf.Sin(t));
    }
}
