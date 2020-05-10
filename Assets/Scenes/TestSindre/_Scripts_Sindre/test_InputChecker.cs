using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_InputChecker
{
    public static bool isGrounded;

    public Vector3 MoveDirection()
    {
        Vector3 dir = new Vector3();
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");
        return dir;
    }

    public bool IsMoving()
    {
        return (MoveDirection() != Vector3.zero && isGrounded);
    }

    public bool Running()
    {
        return (isGrounded && Input.GetKey(KeyCode.LeftShift) && IsMoving());
    }
}
