using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_InputsAnim
{
    public static bool isGrounded;
    public static bool canMove;
    public static bool canClimb;
    public static bool isEating;

    public Vector2 V2_Walking()
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    public bool Shift()
    {
        return Input.GetKey(KeyCode.LeftShift);
    }

    public bool Walking()
    {
        bool idx = V2_Walking() != Vector2.zero && !Shift() && canMove ? true : false;
        return idx;
    }

    public bool Running()
    {
        bool idx = V2_Walking() != Vector2.zero && Shift() && canMove ? true : false;
        return idx;
    }

    public bool Jump()
    {
        return isGrounded && Input.GetKeyDown("space");
    }

    public bool Climbing()
    {
        return (canClimb && Running());
    }

    public bool Falling()
    {
        return (!isGrounded && !Climbing());
    }

    public bool Sniffing()
    {
        return Input.GetKey("f");
    }

    public bool Idle()
    {
        return (!Falling() && !Sniffing() && V2_Walking() == Vector2.zero && !Jump());
    }
}
