using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBehavior : MonoBehaviour
{
    public enum Deaths { Crushed, BadSmell}
    public Deaths deaths;
    public float delayTime = 1f;
    public float behaviorSpeed = 3f;
    public float heightOffset = 0;
    [Header("For bad smell")]
    public GameObject head;
    public ParticleSystem headExplotion;
    public float explodeTime = 1f;
    public float headSize = 3f;

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
                case Deaths.BadSmell:
                    BadSmell();
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

    bool ones;
    GameObject he;
    void BadSmell()
    {
        if (!ones)
        {
            he = target.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).gameObject;
            StartCoroutine(ExplodeHead(he));
            ones = true;
        }
        if(he != null)
            he.transform.localScale = Vector3.MoveTowards(he.transform.localScale, new Vector3(headSize, headSize, headSize), Time.deltaTime * behaviorSpeed);
        
    }

    IEnumerator ExplodeHead(GameObject go)
    {
        yield return new WaitForSeconds(explodeTime);
        Destroy(go);
        Instantiate(headExplotion, go.transform.position, Quaternion.identity);
    }
}
