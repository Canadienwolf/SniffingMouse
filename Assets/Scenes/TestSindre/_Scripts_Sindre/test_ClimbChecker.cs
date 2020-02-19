using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_ClimbChecker : MonoBehaviour
{
    public bool canClimb;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {
            canClimb = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "Player")
        {
            canClimb = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player")
        {
            canClimb = false;
        }
    }
}
