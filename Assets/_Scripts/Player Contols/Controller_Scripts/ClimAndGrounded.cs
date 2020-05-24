using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimAndGrounded : MonoBehaviour
{
    [SerializeField] float climbRange = 1;
    [SerializeField] float groundedRange = 0;
    [SerializeField] LayerMask mask;

    RaycastHit hitGround;
    RaycastHit hitWall;

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckGround();
        WallCheck();
    }

    void CheckGround()
    {
        if (Physics.BoxCast(transform.position + new Vector3(0, .5f, 0), new Vector3(.7f, .25f, .7f), Vector3.down, out hitGround, transform.rotation, groundedRange))
        {
            if(!hitGround.collider.isTrigger)
                InputManager.isGrounded = true;
        }
        else
            InputManager.isGrounded = false;
    }

    void WallCheck()
    {
        if (Physics.BoxCast(transform.position + new Vector3(0, .5f,0), new Vector3(.2f, .75f, .2f), transform.forward, out hitWall, transform.rotation, climbRange, mask))
        {
            if (!hitWall.collider.isTrigger)
                InputManager.canClimb = true;
        }
        else
            InputManager.canClimb = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube((transform.position + new Vector3(0, .5f, 0)) + Vector3.down * groundedRange, new Vector3(.7f, .25f, .7f));
        Gizmos.DrawWireCube((transform.position + new Vector3(0, .5f, 0)) + transform.forward * climbRange, new Vector3(.2f, .75f, .2f));
        if (InputManager.isGrounded)
        {
        }
        if (InputManager.canClimb)
        {
        }
    }
}
