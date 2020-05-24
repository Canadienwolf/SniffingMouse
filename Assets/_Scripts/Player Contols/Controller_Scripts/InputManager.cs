using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{
    public static bool isGrounded;
    public static bool isClimbing;
    public static bool canClimb;
    public static bool isEating;

    //Movement

    public static bool IsMoving()
    {
        if (MoveDirection() != Vector3.zero && !isEating && !Sniffing())
            return true;
        else
            return false;
    }

    public static Vector3 MoveDirection()
    {

        return (new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
    }

    //Run

    public static bool Running()
    {
        return (ShiftCheck() && !canClimb);
    }

    //Jump

    public static bool Jump()
    {
        return (Input.GetKeyDown("space") && isGrounded && !isEating);
    }

    //Climbing
    
    public static bool Climbing()
    {
        return (ShiftCheck() && canClimb);
    }

    private static bool ShiftCheck()
    {
        return (Input.GetKey(KeyCode.LeftShift) && IsMoving());
    }

    //Sniffing

    public static bool Sniffing()
    {
        return (Input.GetKey("f"));
    }
}
