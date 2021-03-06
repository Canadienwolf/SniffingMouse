﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseDestruction : MonoBehaviour
{
    //gamestate variable to use score methods!
    public GameStates gameStates;
    bool broken;
    //object to spawn !
    public GameObject spawnedObj;
   
    //update method !
    private void Update()
    {
        //destroying the broken vase  2 seconds after the collision !
        if (broken)
        {
            //spawning obj !
            Instantiate(spawnedObj,gameObject.transform.position,Quaternion.identity);
            Destroy(gameObject);
            broken = false;
        }
    }
    //detecting colision with the player !
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //help variable!
            broken = true;
            //not needed any more !
            /*  //changing the position/rotation of some parts of the vase in order to look like a destructable object !
              foreach (GameObject child in Children)
              {
                  child.transform.position = new Vector3(child.gameObject.transform.position.x, 1, child.gameObject.transform.position.z);

              }
              //re-positioning
              Children[0].transform.position = new Vector3(Children[0].gameObject.transform.position.x + 2, 1, Children[0].gameObject.transform.position.z);
              Children[1].transform.position = new Vector3(Children[1].gameObject.transform.position.x - 2, 1, Children[1].gameObject.transform.position.z);
              Children[2].transform.position = new Vector3(Children[2].gameObject.transform.position.x, 1, Children[2].gameObject.transform.position.z + 2);
              Children[3].transform.position = new Vector3(Children[3].gameObject.transform.position.x, 1, Children[3].gameObject.transform.position.z - 2);
              //changing rotation
              Children[0].gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 90, -90));
              Children[1].gameObject.transform.rotation = Quaternion.Euler(new Vector3(-180, 90, -90));
              //diactivating the collider!
              this.gameObject.GetComponent<BoxCollider>().enabled = false;*/
            

        }
        

    }
}
