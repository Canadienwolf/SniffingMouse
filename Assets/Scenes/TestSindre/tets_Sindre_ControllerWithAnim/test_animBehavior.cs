using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_animBehavior : MonoBehaviour
{
    private string[] anim_bools = {"Idle", "Walk", "Run", "Falling", "Sniffing", "Climbing" };
    private string[] anim_triggers = {"Jump", "Landing", "Eat", "ToBase" };
    public test_InputsAnim inputs;
    Animator anim;

    void Start()
    {
        inputs = new test_InputsAnim();
        HitGround();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (inputs.Falling())
        {
            UpdateAnim("Falling");
        }
        else if (inputs.Jump())
        {
            UpdateAnim("Jump");
        }
        else if (inputs.Idle())
        {
            UpdateAnim("Idle");
        }
        else if (inputs.Sniffing())
        {
            UpdateAnim("Sniffing");
        }
        else if (inputs.Walking())
        {
            UpdateAnim("Walk");
        }
        else if (inputs.Running())
        {
            UpdateAnim("Run");
        }
    }


    void UpdateAnim(string animState)
    {
        for (int i = 0; i < anim_bools.Length; i++)
        {
            if (animState == anim_bools[i])
            {
                anim.SetBool(animState, true);
            }
            else
            {
                anim.SetBool(anim_bools[i], false);
            }
        }

        for (int i = 0; i < anim_triggers.Length; i++)
        {
            if (animState == anim_triggers[i])
            {
                anim.SetTrigger(animState);
            }
        }
    }

    public void BackToBase()
    {
        UpdateAnim("ToBase");
    }

    public void Falling()
    {
        test_InputsAnim.isGrounded = false;
    }

    public void HitGround()
    {
        test_InputsAnim.isGrounded = true;
    }

    public void CanMove()
    {
        test_InputsAnim.canMove = !test_InputsAnim.canMove;
    }
}
