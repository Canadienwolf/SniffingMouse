using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    public PlayerStatesMovements psm;
    public ParticleSystem explosion;
    public ParticleSystem thrust;
    public GameObject activeDisplayer;

    public float flyHeight = 10f;
    public float flyTime = 3f;
    public float deactiveTime = 5f;

    private GameObject target;
    private ParticleSystem spawnedThrust;
    private bool active;

    private void Start()
    {
        StartCoroutine(SetActive(true, 0));
    }

    void Update()
    {
        if (target != null)
        {
            target.transform.position = Vector3.MoveTowards(target.transform.position, transform.position + new Vector3(0, flyHeight, 0), Time.deltaTime * (flyHeight / flyTime));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player" || other.tag == "Pickable") && active)
        {
            StartCoroutine(SetActive(false, 0));
            target = other.gameObject;
            spawnedThrust = Instantiate(thrust, target.transform.position, Quaternion.identity);
            spawnedThrust.transform.parent = target.transform;
            spawnedThrust.Play();
            Destroy(spawnedThrust, flyTime - 0.1f);
            target.GetComponent<Rigidbody>().useGravity = false;
            target.GetComponent<Rigidbody>().freezeRotation = true;
            Invoke("Explode", flyTime);
            StartCoroutine(SetActive(true, deactiveTime));

            if (other.tag == "Player")
            {
                psm.lockController = true;
                Invoke("Kill", flyTime + 3);
                Destroy(target.transform.GetChild(1).gameObject, flyTime);
            }
            if (other.tag == "Pickable")
            {
                Destroy(target, flyTime);
            }
        }
    }

    void Explode()
    {
        ParticleSystem ps = Instantiate(explosion, target.transform.position, Quaternion.identity);
        ps.Play();
    }

    void Kill()
    {
        SceneManager.LoadScene("menu_ScoreDisplay");
    }

    IEnumerator SetActive(bool idx, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        active = idx;
        activeDisplayer.SetActive(idx);
    }
}
