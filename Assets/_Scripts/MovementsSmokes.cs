using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementsSmokes : MonoBehaviour
{
    public ParticleSystem walk;
    public ParticleSystem jump;
    public ParticleSystem land;
    public ParticleSystem climb;

    private void OnEnable()
    {
        test_GroundCheck.OnLand += LandSmoke;
    }

    private void OnDisable()
    {
        test_GroundCheck.OnLand -= LandSmoke;
    }

    public void ClimbSmoke()
    {
        Instantiate(climb, transform.position, Quaternion.identity);
    }

    public void StepSmoke()
    {
        Instantiate(walk, transform.position, Quaternion.identity);
    }

    public void JumpSmoke()
    {
        Instantiate(jump, transform.position, Quaternion.identity);
    }

    public void LandSmoke()
    {
        Instantiate(land, transform.position, Quaternion.identity);
    }
}
