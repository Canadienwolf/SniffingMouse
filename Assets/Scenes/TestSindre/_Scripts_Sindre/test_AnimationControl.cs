using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations;
using UnityEngine;

public class test_AnimationControl : MonoBehaviour
{
    public PlayerStatesMovements psm;
    public Animator anim;

    void Update()
    {
        anim.SetBool("Moving", psm.isMoving);
        anim.SetBool("Eating", psm.isEating);
        anim.SetBool("Running", psm.isRunning);
        anim.SetBool("Grounded", psm.isGrounded);
        anim.SetBool("Jumping", psm.isJumping);
        anim.SetBool("Climbing", psm.isClimbing);
        anim.SetBool("CaughtBySmell", psm.caughtBySmell);

        if (psm.isEating)
            psm.caughtBySmell = false;
    }
}
