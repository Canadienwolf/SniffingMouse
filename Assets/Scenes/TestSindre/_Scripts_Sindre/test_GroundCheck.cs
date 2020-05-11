using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_GroundCheck : MonoBehaviour
{
    public PlayerStatesMovements psm;
    public bool isGrounded;
    public bool justHit;

    public delegate void Land();
    public static event Land OnLand;

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
            OnLand();
            Invoke("StopJusthit", 0.025f);
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
