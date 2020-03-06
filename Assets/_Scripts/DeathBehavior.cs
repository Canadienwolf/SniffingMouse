using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBehavior : MonoBehaviour
{
    public enum Deaths { Crushed, Exploded, Impaled, BadSmell}
    public Deaths deaths;
    public float delayTime = 1f;
    public float behaviorSpeed = 3f;
    public float heightOffset = 0;

    private GameObject target;

    private bool dead;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (dead)
        {
            switch (deaths)
            {
                case Deaths.Crushed:
                    Chrush();
                    break;
                case Deaths.Exploded:
                    break;
                case Deaths.Impaled:
                    break;
                case Deaths.BadSmell:
                    break;
                default:
                    break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Invoke("Kill", delayTime);
        }
    }

    void Kill()
    {
        dead = true;
    }


    void Chrush()
    {
        target.transform.localScale = Vector3.MoveTowards(target.transform.localScale, new Vector3(2f, .1f, 2), Time.deltaTime * behaviorSpeed);
        target.transform.position = new Vector3(target.transform.position.x, transform.position.y + heightOffset, target.transform.position.z);
    }
}
