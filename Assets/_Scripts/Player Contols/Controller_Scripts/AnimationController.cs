using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    string[] animStates = new string[] {"Idle", "Walking", "Running", "Climbing", "Floating", "Jump", "Eating", "Sniffing"};
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    void Update()
    {
        if (InputManager.isEating)
        {
            SetAnim("Eating");
        }
        else if (InputManager.Sniffing())
        {
            SetAnim("Sniffing");
        }
        else if (InputManager.Jump())
        {
            SetAnim("Jump");
        }
        else if (InputManager.isClimbing)
        {
            SetAnim("Climbing");
        }
        else if (!InputManager.isGrounded && !InputManager.Climbing())
        {
            SetAnim("Floating");
        }
        else if (InputManager.Running())
        {
            SetAnim("Running");
        }
        else if (InputManager.IsMoving())
        {
            SetAnim("Walking");
        }
        else
        {
            SetAnim("Idle");
        }
    }

    void SetAnim(string activeAnim)
    {
        for (int i = 0; i < animStates.Length; i++)
        {
            if(activeAnim == animStates[i])
            {
                anim.SetBool(animStates[i], true);
            }
            else
            {
                anim.SetBool(animStates[i], false);
            }
        }
    }
}
