using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VacuumScript : MonoBehaviour
{
    //max velocity variable !
    public float velocidadMax=0.5f;

    //max,min variables for x,z axis (can be modified in the inspector !)
    public float xMax;
    public float zMax;
    public float xMin;
    public float zMin;

    //variables for x,y axis and time ,angle !
    private float x;
    private float z;
    private float tiempo;
    private float angulo;

    //playerstates variable !
    public PlayerStatesMovements playerStatesA;
    //gamestates variable!
    public GameStates GameStatesA;

    //Player gameObject
    GameObject player;

    //Rigidbody of the object!
    Rigidbody rg;

    //Distance and speed varibles !
    float dist;
    public float speed = 8f;
    bool move = true;

    //checking if it has been triggred more than once !
    bool moreThanOnce;
    //checking if the cheese is triggred by the player
    bool istrigger;

    // Use this for initialization
    void Start()
    {
        //initialisation of the variables at the begining !
        xMax = Random.Range(100, 200);
        zMax = Random.Range(100, 200);
        xMin = Random.Range(-200, -100);
        zMin = Random.Range(-200, -100);
        x = Random.Range(-velocidadMax, velocidadMax);
        z = Random.Range(-velocidadMax, velocidadMax);
        angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
        //transform.localRotation = Quaternion.Euler(0, angulo, 0);

        //getting the rigidbody of the gameobject!
        rg = this.gameObject.GetComponent<Rigidbody>();

        //finding the player Gamobject!
        player = GameObject.FindGameObjectWithTag("Player");
        
        
    }

    // Update is called once per frame
    void Update()
    {

        //calculating the Distance between the mouse and the vacuum cleaner!
         dist = Vector3.Distance(this.gameObject.transform.position, player.transform.position);
        //timer variable updates!
        tiempo += Time.deltaTime;

        //checking if the roomba is allowed to move! 
        if (move == true)
        {
            //checking the necessary conditions(min,max axis) inorder to updates the axis variables and the vacuum rotation!
            if (transform.localPosition.x > xMax)
            {
                x = Random.Range(-velocidadMax, 0.0f);
                angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
                transform.localRotation = Quaternion.Euler(0, angulo, 0);
                tiempo = 0.0f;
            }
            if (transform.localPosition.x < xMin)
            {
                x = Random.Range(0.0f, velocidadMax);
                angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
                transform.localRotation = Quaternion.Euler(0, angulo, 0);
                tiempo = 0.0f;
            }
            if (transform.localPosition.z > zMax)
            {
                z = Random.Range(-velocidadMax, 0.0f);
                angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
                transform.localRotation = Quaternion.Euler(0, angulo, 0);
                tiempo = 0.0f;
            }
            if (transform.localPosition.z < zMin)
            {
                z = Random.Range(0.0f, velocidadMax);
                angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
                transform.localRotation = Quaternion.Euler(0, angulo, 0);
                tiempo = 0.0f;
            }
            //moving the roomba forward !
            rg.transform.Translate(Vector3.forward * Time.deltaTime * 8);
        }
        else
        {
            //checking if the rotation of the roomba has finished!
            if (Quaternion.Dot(transform.rotation, Quaternion.Euler(transform.rotation.x, angulo, transform.rotation.z)) >= 0.997f)
            {
                move = true;
            }
            else
            {
                rg.transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, angulo, 0), 20 * Time.deltaTime);
            }
        }

      

        //updating the axis and angle variables based on the timer!
       /* if (tiempo > 1.0f)
        {
            x = Random.Range(-velocidadMax, velocidadMax);
            z = Random.Range(-velocidadMax, velocidadMax);
            angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
            transform.localRotation = Quaternion.Euler(0, angulo, 0);
            tiempo = 0.0f;
        }

        //moving the vacuum cleaner using the variables already updated !
        transform.localPosition = new Vector3(transform.localPosition.x + x, transform.localPosition.y, transform.localPosition.z + z);*/


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
        if (collision.gameObject.CompareTag("Player"))
        {
            //updating the player state lock controller!
            playerStatesA.lockController = true;
            //Locking the vacuum cleaner movments by freezing the movements variables!
            velocidadMax = 0;
            xMin = 0;
            xMax = 0;
            zMin = 0;
            zMax = 0;
            //Stopping the vacuum shuffing effect!
            speed = 0;
            if (moreThanOnce == false)
            {
                istrigger = true;
            }
            //checking ifthe player collided with that type of cheese !
            if (istrigger == true)
            {
                moreThanOnce = true;
                //calling the losing event (menu)!
                Invoke("Die", 2);
            }
            //calling the loss/win menu
           // Invoke("Die", 2);
        }
        else if (collision.gameObject.name != "Ground")
        {
            x = Random.Range(-velocidadMax, velocidadMax);
            z = Random.Range(-velocidadMax, velocidadMax);
            angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
            move = false;
            
        }

    }

    //calling the losing event!
    void Die()
    {
        
       
        //calling our static endgame method !
        GameStatesA.EndGame("You got crushed, you lost score points !", -5);
        
    }

    private void OnApplicationQuit()
    {
        //updating the player state lock controller before quit !
        playerStatesA.lockController = false;
    }

}
