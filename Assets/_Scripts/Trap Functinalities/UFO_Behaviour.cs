using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class UFO_Behaviour : MonoBehaviour
{
    //The gameobject to follow
    private Transform player;
    public float followSharpness = 10f;
    public float frontOffset = 10f;
    public GameObject halo;

    //Score
    public TextMesh score;
    public GameStates gs;
    
    //Timer
    public Slider timeLeft;
    
    
    [Header("Turn speed of the UFO")]
    public float turnSpeed = 1f;

    private Vector3 _followOffset;
    private NavMeshAgent agent;
    
    // Start is called before the first frame update
    void Start()
    {
        //Cache the initial offest at the time of load/ spawn
        //_followOffset = transform.position - player.position;
        timeLeft.maxValue = gs.timer;
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    Vector3 targetPos;
    // Update is called once per frame
    void Update()
    {

        if (gs.timer > 0)
        {
            halo.SetActive(false);
            targetPos = new Vector3(player.position.x, transform.position.y, player.position.z) + player.forward * frontOffset;
        }
        else
        {
            halo.SetActive(true);
            targetPos = new Vector3(player.position.x, transform.position.y, player.position.z);
        }
        agent.SetDestination(targetPos);

        //transform.position = player.position + _followOffset;

        transform.Rotate(new Vector3(0, turnSpeed, 0) * Time.deltaTime);

        score.text = gs.score.ToString();
        
        timer();
    }

    private void LateUpdate()
    {
        //playerTailing();
    }

    //Timer for how much time that you have left before the UFO starts turning to a trap and the map becoming more difficult.
    public void timer()
    {
        timeLeft.value = gs.timer;
    }

    //Makes the UFO follow the player whenever the player moves.
    void playerTailing()
    {
        //Apply offset to get a target position.
        Vector3 targetPosition = player.position + _followOffset;
        
        //Keep our Y position unchanged.
        targetPosition.y = transform.position.y;
        
        //smooth follow
        transform.position += (targetPosition - transform.position) * followSharpness;
    }
}
