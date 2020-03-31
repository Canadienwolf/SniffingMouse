﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CagewFallingDoor : MonoBehaviour
{
    public GameObject door;
    public GameObject cage;
    public GameObject cheese;

    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        door.GetComponent<Rigidbody>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (door.transform.localPosition.y < 0.1f && target != null && cage != null)
        {
            FindObjectOfType<DeathMusic>().dying = true;
            Invoke("CatchPlayer", 2);
        }
        if (cage == null)
        {
            cheese.transform.parent = null;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Pickable")
        {
            door.GetComponent<Rigidbody>().isKinematic = false;
            if (other.tag == "Player")
            {
                target = other.gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            target = null;
        }
    }
}
