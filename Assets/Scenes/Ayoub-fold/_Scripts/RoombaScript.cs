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
    public float dist, speed = 8f;

    //Rigidbody of the object!
    Rigidbody rg;

    //help variables !
    bool move = true;
    float timer=0;
    float randomNumber;
    bool finished=false;
    int help;

    //max velocity variable !
    public float velocidadMax;
    //variables for x,y axis and time ,angle !
    private float x;
    private float z;
   // private float tiempo;
    private float angulo;

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
        //Debug.Log(timer);

        //calculating the Distance between the mouse and the vacuum cleaner!
        dist = Vector3.Distance(this.gameObject.transform.position, player.transform.position);

        if (move==true)
        {
            //moving the roomba forward !
            rg.transform.Translate(Vector3.forward * Time.deltaTime * speed);

        }
        else
        {

            if (Quaternion.Dot(transform.rotation, Quaternion.Euler(transform.rotation.x, angulo, transform.rotation.z)) >= 0.997f)
            {
                move = true;
            }
            else
            {
                rg.transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, angulo, 0), 20 * Time.deltaTime);
            }

        }


        

        Debug.Log(randomNumber);
        Debug.Log(rg.transform.rotation.y) ;
       
       

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
        timer = 0;
        // move = false;
        // Debug.Log(collision.gameObject.name);

         if (collision.gameObject.CompareTag("Player"))
        {
            move = false;
            //updating the player state lock controller!
            playerStatesA.lockController = true;
            //Stopping the vacuum shuffing effect!
            speed = 0;
            //losing score!
            GameStatesA.LoseScorePoints();
            //calling the loss/win menu
            Invoke("Die", 2);

           
        }else if (collision.gameObject.name != "Ground")
        {
            move = false;
            //rg.transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
            randomNumber = Random.Range(45, 260);
            x = Random.Range(-velocidadMax, velocidadMax);
            z = Random.Range(-velocidadMax, velocidadMax);
            angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
            //rg.transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, randomNumber, 0), 20 * Time.deltaTime);
            //need to modify that code !
            //rg.transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, randomNumber, 0), 20 * Time.deltaTime);
            //changing the rotation axis for the roomba !
            // rg.transform.Rotate(new Vector3(0, Random.Range(90, 180), 0));
            // rg.transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, Random.Range(90, 180), 0), speed * Time.deltaTime);
            // rg.transform.Translate(Vector3.forward * Time.deltaTime);
            //letting the roomba moves again after few seconds!
            // move = true;
        }


    }
    


    //calling the losing event!
    void Die()
    {
        GameStatesA.EndGame("You Lost !", -5);
    }

    //waiting for 3 seconds before moving again !
    IEnumerator moveWait()
    {
        yield return new WaitForSeconds(3.0f);
        move = true;
        finished = false;
    }

    private void OnApplicationQuit()
    {
        //updating the player state lock controller before quit !
        playerStatesA.lockController = false;
    }

}
