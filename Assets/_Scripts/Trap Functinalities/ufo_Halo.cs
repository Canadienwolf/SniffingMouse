using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ufo_Halo : MonoBehaviour
{
    public PlayerStatesMovements psm;
    public float speed = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            psm.lockController = true;
            foreach (Collider c in other.GetComponents<Collider>())
            {
                c.isTrigger = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.position += Vector3.up * speed * Time.deltaTime;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            psm.lockController = false;
            foreach (Collider c in other.GetComponents<Collider>())
            {
                c.isTrigger = false;
            }
        }
    }
}
