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
    public float driveTime = 5f;
    public float playerHeightOffest = 3f;
    public GameObject drivingCam;
    public GameObject deathCam;
    public PlayerStatesMovements psm;
    public GameObject explosion;
    public GameObject CrashSFX;

    private bool hit, canControl;
    private Vector3 randRot;
    private GameObject player;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        drivingCam.SetActive(false);
        deathCam.SetActive(false);
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hit)
        {
            transform.Translate(Vector3.forward * driveSpeed * Time.deltaTime);
            if(canControl)
                transform.rotation *= Quaternion.Euler(new Vector3(0, Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed * 5, 0));
        }
    }

    void Hit()
    {
        hit = true;
        canControl = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.gameObject;
            psm.lockController = true;
            randRot = new Vector3(0, Random.Range(-360, 360), 0);
            drivingCam.SetActive(true);
            GetComponent<Collider>().isTrigger = false;
            other.transform.parent = gameObject.transform;
            other.transform.position = transform.position + new Vector3(0, playerHeightOffest, 0);
            other.transform.rotation = transform.rotation;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            Invoke("Hit", startDelay);
            Invoke("ReleasePlayer", driveTime);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag != "Player")
        {
            if (canControl)
            {
                CrashSFX.SetActive(true);
                deathCam.SetActive(true);
                psm.lockController = true;
                FindObjectOfType<DeathMusic>().dying = true;
                CancelInvoke();
                Invoke("Transition", deathDelay - 0.6f);
                Invoke("Die", deathDelay);
            }
            hit = false;
            Instantiate(explosion, transform.position + new Vector3(0, playerHeightOffest, 0), Quaternion.identity);
            GetComponent<test_Cartrap>().enabled = false;
            GetComponent<BoxCollider>().isTrigger = false;
        }
    }

    void ReleasePlayer()
    {
        player.transform.parent = null;
        psm.lockController = false;
        drivingCam.SetActive(false);
        canControl = false;
        Invoke("UnsetKin", 1f);
    }

    void UnsetKin()
    {
        player.GetComponent<Rigidbody>().isKinematic = false;
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
