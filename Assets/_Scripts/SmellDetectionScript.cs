using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SmellDetectionScript : MonoBehaviour
{
    //variables needed !
    public PlayerStatesMovements playerStatesB;
    public GameStates GameStatesA;
    GameObject player;
    bool affected;
    float timeLeft;

    public float frequency = 16f; // Speed of sine movement !
    public float magnitude = 2f; // Size of sine movement
    public float effectTime = 5f;
    public ParticleSystem drunkBobbles;

    private GameObject drunkBobble;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        Debug.Log(player.transform.position);

        if (affected)
        {
            //player.transform.position += new Vector3(Mathf.Sin(Time.time * frequency) * magnitude * player.GetComponent<test_PlayerMovement02>().currentSpeed * 0.1f, 0, 0);
            float angle = Mathf.Sin(Time.time * frequency) * magnitude * Mathf.Rad2Deg;
            player.transform.localRotation *= Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.up), Time.deltaTime * player.GetComponent<test_PlayerMovement02>().currentSpeed);
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                affected = false;
            }
        }
        else
        {
            if (drunkBobble != null)
                Destroy(drunkBobble);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            affected = true;
            timeLeft = effectTime;
            if (drunkBobble == null)
            {
                drunkBobble = Instantiate(drunkBobbles.gameObject, other.transform.position + new Vector3(0, 2, 0), Quaternion.Euler(-90, 0, 0));
                drunkBobble.transform.parent = other.transform;
            }
        }
    }

    //for detecting the collisions triggered !
    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            affected = true;
            timeLeft = effectTime;
        }

    }

    //calling the losing event!
    void Die()
    {
        //saving the score in that current level you're in in order to display it later on !
        PlayerPrefs.SetInt("PreviousScore" + SceneManager.GetActiveScene().buildIndex.ToString(), GameStatesA.score);
        //loading the loss/win menu !
        SceneManager.LoadScene("menu_ScoreDisplay");
    }
}
