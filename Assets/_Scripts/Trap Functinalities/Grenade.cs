using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public ParticleSystem activeDisplayer;
    public ParticleSystem explotion;

    public float detonationTime = 3f;
    public float killRange = 5f;

    private bool active;
    private GameObject target;

    void Update()
    {
        if (active && target != null)
        {
            activeDisplayer.Play();
            Invoke("Explode", detonationTime);
            active = false;
        }
    }

    void Explode()
    {
        explotion.Play();

        if (Vector3.Distance(target.transform.position, transform.position) < killRange)
            print("Dead");
        transform.GetChild(0).gameObject.SetActive(false);
        Destroy(this.gameObject, explotion.main.duration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            active = true;
            target = other.gameObject;
        }
    }
}
