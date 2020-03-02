using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoombaScript : MonoBehaviour
{
    //playerstates variable !
    public PlayerStatesMovements playerStatesA;
    //gamestates variable!
    public GameStates GameStatesA;

    //Player gameObject
    GameObject player;

    //Distance and speed varibles !
    float dist, speed = 8f;

    //Rigidbody of the object!
    Rigidbody rg;

    //help variables !
    bool move = true;
    float timer=0;

    // Start is called before the first frame update
    void Start()
    {
        //finding the player Gamobject!
        player = GameObject.FindGameObjectWithTag("Player");
        //getting the rigidbody of the gameobject!
        rg = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(timer);

        //calculating the Distance between the mouse and the vacuum cleaner!
        dist = Vector3.Distance(this.gameObject.transform.position, player.transform.position);

        if (move==true)
        {
            //moving the roomba forward !
            rg.transform.Translate(Vector3.forward * Time.deltaTime * speed);

        }
        

        //checking for the distance between the mouse and the vacuum cleaner!
        if (dist < 8f)
        {
            // Move our position a step closer to the target.
            float step = speed * Time.deltaTime;
            // Moving the mouse towards the vacuum !
            player.transform.position = Vector3.MoveTowards(player.transform.position, transform.position, step);
        }

    }

    //for detecting the collision with the player!
    private void OnCollisionEnter(Collision collision)
    {
        //just for the roomba movement thingy !
        timer = GameStatesA.timer-3;

        Debug.Log(collision.gameObject.name);

        //detecting the collision with the player or the other stuff!
        if (collision.gameObject.CompareTag("Player"))
        {
            //updating the player state lock controller!
            playerStatesA.lockController = true;
            //Stopping the vacuum shuffing effect!
            speed = 0;
            //losing score!
            GameStatesA.LoseScorePoints();
            //calling the loss/win menu
            Invoke("Die", 2);
        }
        else if (collision.gameObject.name=="Ground")
        {
            move = true;
        }
        else
        {
            //interupting the roomba movement!
            //move = false;
            //changing the rotation axis for the roomba !
             rg.transform.Rotate(new Vector3(0, Random.Range(90, 180), 0));
            // rg.transform.Translate(Vector3.forward * Time.deltaTime);
            //letting the roomba moves again after few seconds!
            move = true;

        }
    }

    //calling the losing event!
    void Die()
    {
        GameMangerScript.EndGame("You Lost !", -5);
        //saving the score in that current level you're in in order to display it later on !
       // PlayerPrefs.SetInt("PreviousScore" + SceneManager.GetActiveScene().buildIndex.ToString(), GameStatesA.score);
    }

    private void OnApplicationQuit()
    {
        //updating the player state lock controller before quit !
        playerStatesA.lockController = false;
    }

}
