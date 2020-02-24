using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_ClimbChecker : MonoBehaviour
{
    public bool canClimb;
    public bool justHit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" && other.tag != "Pickable" && !other.GetComponent<Collider>().isTrigger)
        {
            canClimb = true;
            justHit = true;
            Invoke("StopHit", 0.1f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "Player" && other.tag != "Pickable" && !other.GetComponent<Collider>().isTrigger)
        {
            canClimb = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player" && other.tag != "Pickable" && !other.GetComponent<Collider>().isTrigger)
        {
            canClimb = false;
        }
    }

    void StopHit()
    {
        justHit = false;
    }
}
