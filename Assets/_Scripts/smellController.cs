using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UIElements;

public class smellController : MonoBehaviour
{
    //Public-
    public Transform[] wayPointList;
    public int currentWayPoint = 0;
    public float speed = 4f;
    
    //Private
    private bool chasing = false;
    private Transform targetWayPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        patrol();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentWayPoint < this.wayPointList.Length)
        {
            if(targetWayPoint == null)
                targetWayPoint = wayPointList[currentWayPoint];
            patrol();
        }
        else
        {
            if (currentWayPoint == wayPointList.Length)
            {
                currentWayPoint = -1;
            }
        }
    }

    private float sideMoveTime;
    private float currentPos;

    public void patrol()
    {
        transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint.position - transform.position,
            speed * Time.deltaTime * 5, 0.0f);
        
        //Adding sidways movement
        sideMoveTime += Time.deltaTime * 7f;        //Counts the time times 7
        currentPos = Mathf.Sin(sideMoveTime) * 0.02f;   //Makes variable go back and forth based on time
        transform.position += new Vector3(currentPos, 0, 0);    //Moves the object sideways
        
        transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position,   speed*Time.deltaTime);
        
        if(transform.position == targetWayPoint.position)
        {
            //currentWayPoint = wayPointList[Random.Range()];
            currentWayPoint ++;

            //Ayoub : need to be change because index is out of range !
            targetWayPoint = wayPointList[currentWayPoint];
        }
    }
}

