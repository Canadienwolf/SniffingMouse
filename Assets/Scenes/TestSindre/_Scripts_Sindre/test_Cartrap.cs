using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_Cartrap : MonoBehaviour
{
    //always have a gamestate declared if u want to use endgame(new approach!)
    public GameStates gameStatesA;
    public float startDelay = 1f;
    public float driveSpeed = 5f;
    public float turnSpeed = 10f;
    public float deathDelay = 3f;
    public float playerHeightOffest = 3f;
    public GameObject drivingCam;
    public GameObject deathCam;
    public PlayerStatesMovements psm;
    public GameObject explosion;

    private bool hit;
    private Vector3 randRot;

    // Start is called before the first frame update
    void Start()
    {
        drivingCam.SetActive(false);
        deathCam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (hit)
        {
            transform.Translate(Vector3.forward * driveSpeed * Time.deltaTime);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(randRot), Time.deltaTime * turnSpeed);
        }
    }

    void Hit()
    {
        hit = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            psm.lockController = true;
            randRot = new Vector3(0, Random.Range(-360, 360), 0);
            drivingCam.SetActive(true);
            GetComponent<Collider>().isTrigger = false;
            other.transform.parent = gameObject.transform;
            other.transform.position = transform.position + new Vector3(0, playerHeightOffest, 0);
            other.transform.rotation = transform.rotation;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            Invoke("Hit", startDelay);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag != "Player")
        {
            hit = false;
            deathCam.SetActive(true);
            FindObjectOfType<DeathMusic>().dying = true;
            Instantiate(explosion, transform.position + new Vector3(0, playerHeightOffest, 0), Quaternion.identity);
            Invoke("Transition", deathDelay - 0.6f);
            Invoke("Die", deathDelay);
        }
    }

    void Transition()
    {
        GameObject.Find("SceneTransition").GetComponent<Animator>().SetTrigger("EndLevel");
    }

    void Die()
    {
        DeathScreensScript.sprite = 1;
        gameStatesA.EndGame("You crashed!", (-15));
    }
}
