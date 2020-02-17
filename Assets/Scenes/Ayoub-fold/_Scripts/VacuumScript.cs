using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VacuumScript : MonoBehaviour
{
    //max velocity variable !
    public float velocidadMax;

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

    //Player gameObject
    GameObject player;

    //Distance and speed varibles !
    float dist, speed = 8f;

    // Use this for initialization
    void Start()
    {
        //initialisation of the variables at the begining !
        x = Random.Range(-velocidadMax, velocidadMax);
        z = Random.Range(-velocidadMax, velocidadMax);
        angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
        transform.localRotation = Quaternion.Euler(0, angulo, 0);

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

        //updating the axis and angle variables based on the timer!
        if (tiempo > 1.0f)
        {
            x = Random.Range(-velocidadMax, velocidadMax);
            z = Random.Range(-velocidadMax, velocidadMax);
            angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
            transform.localRotation = Quaternion.Euler(0, angulo, 0);
            tiempo = 0.0f;
        }

        //moving the vacuum cleaner using the variables already updated !
        transform.localPosition = new Vector3(transform.localPosition.x + x, transform.localPosition.y, transform.localPosition.z + z);

        //checking for the distance between the mouse and the vacuum cleaner!
        if (dist < 12f)
        {
            //updating the player state lock controller !
            playerStatesA.lockController = true;
            // Move our position a step closer to the target.
            float step = speed * Time.deltaTime;
            // Moving the mouse towards the vacuum !
            player.transform.position = Vector3.MoveTowards(player.transform.position, transform.position, step);
        }
        else
        {
            //updating the player state lock controller!
            playerStatesA.lockController = false;
        }

        //just for test !
        Debug.Log("dist :" + dist);
    }

    //for detecting the collision with the player!
    private void OnCollisionStay(Collision collision)
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
            //calling the loss/win menu
            Invoke("Die", 2);
        }
    }

    //calling the losing event!
    void Die()
    {
        //loading the loss/win menu !
        SceneManager.LoadScene("menu_ScoreDisplay");
    }

    private void OnApplicationQuit()
    {
        //updating the player state lock controller before quit !
        playerStatesA.lockController = false;
    }

}
