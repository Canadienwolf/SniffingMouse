using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using UnityEngine.UI;

public class UFO_Behaviour : MonoBehaviour
{

    
    //The gameobject to follow
    public Transform player;
    public float followSharpness = 10f;

    //Score
    public TextMesh score;
    public GameStates gs;
    
    //Timer
    public GameObject timeSlider;
    private int timeLeft;
    
    
    [Header("Turn speed of the UFO")]
    public float turnSpeed = 1f;

    private Vector3 _followOffset;
    
    // Start is called before the first frame update
    void Start()
    {
        //Cache the initial offest at the time of load/ spawn
        _followOffset = transform.position - player.position;
        timeSlider.GetComponent<Slider>().maxValue = gs.timer;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + _followOffset;
        
        transform.Rotate(0, turnSpeed, 0);

        score.text = gs.score.ToString();
        
        timer();
    }

    private void LateUpdate()
    {
        playerTailing();
        
        
    }

    //Timer for how much time that you have left before the UFO starts turning to a trap and the map becoming more difficult.
    public void timer()
    {
        //timeLeft = gs.timer.ToString();
        //sliderTextString = textUpdateNumber.ToString();
        //sliderText.text = sliderTextString;
        //timeLeft = timeSlider.value

        timeSlider.GetComponent<Slider>().value = gs.timer;
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
