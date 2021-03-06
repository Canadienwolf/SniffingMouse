﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Cinemachine;

public class RocketLauncher : MonoBehaviour
{
    public PlayerStatesMovements psm;
    public ParticleSystem explosion;
    public ParticleSystem thrust;
    public GameObject activeDisplayer;
    public GameObject followPlayer;
    public CinemachineVirtualCamera cvc;

    public float flyHeight = 10f;
    public float flyTime = 3f;
    public float deactiveTime = 5f;

    private GameObject target;
    private ParticleSystem spawnedThrust;
    private bool active;
    
    //---------------SFX related----------------------------
    //Link to the GameObject that has the sound for when the rocket starts
    public GameObject RocketSFX;

    private void Start()
    {
        StartCoroutine(SetActive(true, 0));
    }

    void Update()
    {
        if (target != null)
        {
            target.transform.position = Vector3.MoveTowards(target.transform.position, transform.position + new Vector3(0, flyHeight, 0), Time.deltaTime * (flyHeight / flyTime));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player" || other.tag == "Pickable") && active)
        {
            StartCoroutine(SetActive(false, 0));
            target = other.gameObject;
            spawnedThrust = Instantiate(thrust, target.transform.position, Quaternion.identity);
            spawnedThrust.transform.parent = target.transform;
            spawnedThrust.Play();
            Destroy(spawnedThrust, flyTime - 0.1f);
            target.GetComponent<Rigidbody>().useGravity = false;
            target.GetComponent<Rigidbody>().freezeRotation = true;
            Invoke("Explode", flyTime);
            RocketSFX.SetActive(true);
            StartCoroutine(SetActive(true, deactiveTime));

            if (other.tag == "Player")
            {
                psm.lockController = true;
                followPlayer.transform.parent = other.transform;
                cvc.gameObject.SetActive(true);
                cvc.transform.position = other.transform.parent.transform.GetChild(2).transform.position;
                FindObjectOfType<DeathMusic>().dying = true;
                Invoke("Transition", flyTime + 2.4f);
                Invoke("Kill", flyTime + 3);
                Destroy(other.transform.GetChild(0).gameObject, flyTime);
            }
            if (other.tag == "Pickable")
            {
                Destroy(target, flyTime);
            }
        }
    }

    void Explode()
    {
        ParticleSystem ps = Instantiate(explosion, target.transform.position, Quaternion.identity);
        ps.Play();
        
        
    }

    void Transition()
    {
        GameObject.Find("SceneTransition").GetComponent<Animator>().SetTrigger("EndLevel");
    }

    void Kill()
    {
        DeathScreensScript.sprite = 7;
        SceneManager.LoadScene("menu_ScoreDisplay");
    }

    IEnumerator SetActive(bool idx, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        active = idx;
        activeDisplayer.SetActive(idx);
    }
}
