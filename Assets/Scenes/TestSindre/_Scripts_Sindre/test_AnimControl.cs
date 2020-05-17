using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class test_AnimControl : MonoBehaviour
{
    test_InputChecker inputCheck = new test_InputChecker();
    Animator anim;
    string[] animStates = new string[] {"Idle", "Walking", "Running", "Jump" };

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inputCheck.JumpStart())
        {
            SetAnimBool("Jump");
        }
        else if (inputCheck.Running())
        {
            SetAnimBool("Running");
        }
        else if (inputCheck.IsMoving())
        {
            SetAnimBool("Walking");
        }
        else
        {
            SetAnimBool("Idle");
        }
    }

    void SetAnimBool(string active)
    {
        anim.SetBool(active, true);
        for (int i = 0; i < animStates.Length; i++)
        {
            if (active != animStates[i])
                anim.SetBool(animStates[i], false);
        }
    }
}
