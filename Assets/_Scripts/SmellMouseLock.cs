﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SmellMouseLock : MonoBehaviour
{
    //--------------------------------------------//
    
    //private
    private GameObject _player;
    private bool mouseCaught;
    private float timeThreshold = 0.5f;
    private float lastButtonPressed;
    public Transform _cheeseParent;
    private int buttonCount = 0;
    private float timeCounter;
    //--------------------------------------------//

    //public
    public PlayerStatesMovements psm;
    [Header("Times the player has to press a button to get relesed")]
    public int buttonCountThreshold = 5;
    [Header("How fast the mouse will transported to cheeses position")]
    public float speed;
    public float maxTime = 5;

    private float jumpTime;
    private float currentHeight;
    //---------------------------------------------//

    // Start is called before the first frame update
    void Start()
    {
        
        //Finding the location of where the parent is.
        //_cheeseParent = transform.parent.transform.parent;
        
        //Find the player
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnDisable()
    {
        //anim.SetBool("CaughtBySmell", false);
    }

    // Update is called once per frame
    void Update()
    {
        psm.caughtBySmell = mouseCaught;
        if (mouseCaught) 
        {
            if (Vector3.Distance(_player.transform.position, _cheeseParent.position) > 1)
                _player.transform.position = Vector3.MoveTowards(_player.transform.position, _cheeseParent.position, speed * Time.deltaTime * 100);
            //_player.GetComponent<Rigidbody>().useGravity = false;
            Vector3 desiredDir = _cheeseParent.position - _player.transform.position;
            float angle = Mathf.Atan2(desiredDir.x, desiredDir.z) * Mathf.Rad2Deg;
            _player.transform.rotation = Quaternion.Lerp(_player.transform.rotation, Quaternion.AngleAxis(angle, Vector3.up), Time.deltaTime * 10);
            timeCounter += Time.deltaTime;
            /*
            if (Input.GetKeyDown("q") || Input.GetButtonDown("Cancel"))
            {
                buttonCount ++;
            }
            if (buttonCount == buttonCountThreshold || timeCounter > maxTime || _player.GetComponent<test_PlayerMovement03>().cc.canClimb)
            {
                playerstatesA.lockController = false;
                buttonCount = 0;
                mouseCaught = false;
                //_player.GetComponent<Rigidbody>().useGravity = true;
            }
            /*
            if(_player.GetComponent<test_PlayerMovement03>() != null)
            {
                if (_player.GetComponent<test_PlayerMovement03>().psm.isEating)
                {
                    buttonCount = 0;
                    mouseCaught = false;
                }
            }
            */
            
        }
        else
        {
            timeCounter = 0;
        }
    }
    
    public PlayerStatesMovements playerstatesA;
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "Player" && !playerstatesA.lockController)
        {
            playerstatesA.lockController = true;
            mouseCaught = true;
        }
    }
}
/*Things were done here*/
