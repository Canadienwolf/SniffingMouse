using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CallMethod : MonoBehaviour
{
    [SerializeField] SpawnParticle leftLeg;
    [SerializeField] SpawnParticle rightLeg;
    [SerializeField] ParticleSystem landJump;

    public void SpawnLandJump()
    {
        Instantiate(landJump, transform.position, transform.rotation);
    }

    public void LeftStep()
    {
        leftLeg.SpawnTheParticle();
    }

    public void RightStep()
    {
        rightLeg.SpawnTheParticle();
    }
}
