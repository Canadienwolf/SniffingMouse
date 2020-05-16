using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public PlayerStatesMovements psm;
    public ParticleSystem activeDisplayer;
    public ParticleSystem areaDisplayer;
    public ParticleSystem[] explotion;

    public float detonationTime = 3f;
    public float killRange = 5f;

    private bool active;
    private GameObject target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (active && target != null)
        {
            activeDisplayer.Play();
            areaDisplayer.Play();
            Invoke("Explode", detonationTime);
            active = false;
        }
    }

    void Explode()
    {
        for (int i = 0; i < explotion.Length; i++)
        {
            explotion[i].gameObject.SetActive(true);
            explotion[i].Play();
            explotion[i].transform.parent = null;
        }

        if (Vector3.Distance(target.transform.position, transform.position) < killRange)
        {
            psm.lockController = true;
            target.transform.GetChild(0).gameObject.SetActive(false);
            FindObjectOfType<DeathMusic>().dying = true;
            Invoke("Transition", detonationTime - 0.6f);
            Invoke("Kill", detonationTime);
        }
        else
        {
            gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        transform.GetChild(0).gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Pickable")
        {
            Explode();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Pickable")
        {
            active = true;
        }
    }

    void Transition()
    {
        GameObject.Find("SceneTransition").GetComponent<Animator>().SetTrigger("EndLevel");
    }
    void Kill()
    {
        DeathScreensScript.sprite = 3;
         SceneManager.LoadScene("menu_ScoreDisplay", LoadSceneMode.Single);
        
    }
}
