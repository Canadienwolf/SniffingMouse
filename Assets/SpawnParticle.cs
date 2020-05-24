using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParticle : MonoBehaviour
{
    [SerializeField] ParticleSystem ps;
    [SerializeField] bool spawnOnStart;

    void Start()
    {
        if (spawnOnStart)
        {
            SpawnTheParticle();
        }
    }

    public void SpawnTheParticle()
    {
        Instantiate(ps, transform.position, transform.rotation);
    }
}
