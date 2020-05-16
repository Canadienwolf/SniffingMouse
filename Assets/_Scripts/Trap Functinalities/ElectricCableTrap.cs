using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class ElectricCableTrap : MonoBehaviour
{
    public ParticleSystem lightning;
    public GameObject cam;
    public PlayerStatesMovements playerstatesA;
    public GameStates gameStates;
    
    //------------------------------SFX---------------------------------------------
    private ParticleSystem _spark;

    private void Start()
    {
        cam.SetActive(false);
        _spark= GetComponent<ParticleSystem>();



    }
 
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerstatesA.lockController = true;
            if (playerstatesA.isGrounded) other.transform.position += new Vector3(0, 0.5f, 0);
            Instantiate(lightning, other.transform.position, Quaternion.identity);
            cam.SetActive(true);
            cam.transform.position = other.transform.parent.transform.GetChild(2).transform.position;
            cam.GetComponent<CinemachineVirtualCamera>().LookAt = other.transform;
            FindObjectOfType<DeathMusic>().dying = true;
            Invoke("Transition", 2.4f);
            Invoke("Kill", 3);
            StartCoroutine (sparking());
        }
    }

    void Transition()
    {
        GameObject.Find("SceneTransition").GetComponent<Animator>().SetTrigger("EndLevel");
    }

    void Kill()
    {
        DeathScreensScript.sprite = 2;
        gameStates.EndGame("You got electrocuted", -15);
    }

    private void Update()
    {
        
    }

    IEnumerator sparking()
    {
        _spark.Play();
        //TODO Gotta reference the fmod event emitter and play a sound that is also on the gameobject that the script is on.
        
        
        yield return new WaitForSeconds(10);
    }
}
