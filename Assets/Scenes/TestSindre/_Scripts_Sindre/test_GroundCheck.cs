using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_GroundCheck : MonoBehaviour
{
    public PlayerStatesMovements psm;
    public bool isGrounded;
    public bool justHit;

    private void Update()
    {
        psm.isGrounded = isGrounded;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" && !other.GetComponent<Collider>().isTrigger && other.tag != "Pickable")
        {
            isGrounded = true;
            justHit = true;
            Invoke("StopJusthit", 0.25f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "Player" && !other.GetComponent<Collider>().isTrigger && other.tag != "Pickable")
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player" && !other.GetComponent<Collider>().isTrigger)
            isGrounded = false;
    }

    void StopJusthit()
    {
        justHit = false;
    }

    public void Grounded(bool idx)
    {
        isGrounded = idx;
    }
}
