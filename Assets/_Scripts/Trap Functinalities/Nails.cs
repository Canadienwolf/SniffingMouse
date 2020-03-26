using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Nails : MonoBehaviour
{
    public ParticleSystem hit;
    public GameObject head;

    private bool died;
    //always declare a gamestates in order to use score functions/endgame method !
    public GameStates gameStatesA;
    public PlayerStatesMovements psm;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !died)
        {
            died = true;
            collision.gameObject.GetComponent<test_PlayerMovement03>().psm.lockController = true;
            ParticleSystem ps = Instantiate(hit, collision.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            ps.Play();
            GameObject go = Instantiate(head, collision.transform.position, collision.transform.localRotation);
            go.transform.GetChild(0).gameObject.GetComponent<Rigidbody>().AddForce(collision.gameObject.transform.forward + Vector3.up * collision.gameObject.GetComponent<test_PlayerMovement03>().currentMoveSpeed, ForceMode.Impulse);
            go.transform.GetChild(1).gameObject.SetActive(true);
            go.transform.GetChild(1).transform.position = collision.transform.parent.transform.GetChild(2).transform.position;
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            psm.lockController = true;
            Invoke("Kill", 5);
        }
    }

    void Kill()
    {
        gameStatesA.EndGame("You got impaled", -15);
    }
}
