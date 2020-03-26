using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElectricCableTrap : MonoBehaviour
{
    public ParticleSystem lightning;
    public GameObject cam;

    public PlayerStatesMovements playerstatesA;
    public GameStates gameStates;

    private void Start()
    {
        cam.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerstatesA.lockController = true;
            if (playerstatesA.isGrounded) other.transform.position += new Vector3(0, 0.5f, 0);
            Instantiate(lightning, other.transform.position, Quaternion.identity);
            cam.SetActive(true);
            cam.transform.position = other.transform.parent.transform.GetChild(2).transform.position;

            Invoke("Kill", 3);
        }
    }

    void Kill()
    {
        gameStates.EndGame("You got electrocuted", -15);
    }
}
