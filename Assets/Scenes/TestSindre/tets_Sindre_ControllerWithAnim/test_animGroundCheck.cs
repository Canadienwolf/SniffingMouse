using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_animGroundCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        test_InputsAnim.isGrounded = true;
    }

    private void OnTriggerStay(Collider other)
    {
        test_InputsAnim.isGrounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        test_InputsAnim.isGrounded = false;
    }
}
