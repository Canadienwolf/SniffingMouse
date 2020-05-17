using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_GroundChecker : MonoBehaviour
{
    public bool grounded;

    void Update()
    {
        grounded = test_InputChecker.isGrounded;
    }

    private void OnTriggerEnter(Collider other)
    {
        test_InputChecker.isGrounded = true;
    }

    private void OnTriggerStay(Collider other)
    {
        test_InputChecker.isGrounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        test_InputChecker.isGrounded = false;
    }
}
