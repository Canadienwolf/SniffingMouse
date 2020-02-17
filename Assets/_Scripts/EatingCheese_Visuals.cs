using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CheeseScript))]
public class EatingCheese_Visuals : MonoBehaviour
{
    public ParticleSystem ps;

    private CheeseScript cs;
    private bool startedPlaying;

    private void Start()
    {
        cs = GetComponent<CheeseScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cs.target != null && cs.playerstatesA.isEating)
        {
            if (!startedPlaying)
            {
                ps.Play();
                startedPlaying = true;
            }

            transform.localScale = Vector3.MoveTowards(transform.localScale, Vector3.zero, Time.deltaTime * 2/cs.eatTime);
        }
    }
}
