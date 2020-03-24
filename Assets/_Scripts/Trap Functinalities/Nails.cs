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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !died)
        {
            died = true;
            collision.gameObject.GetComponent<test_PlayerMovement03>().psm.lockController = true;
            ParticleSystem ps = Instantiate(hit, collision.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            ps.Play();
            GameObject go = Instantiate(head, collision.transform.position, head.transform.rotation);
            go.GetComponent<Rigidbody>().AddForce(collision.gameObject.transform.forward * collision.gameObject.GetComponent<test_PlayerMovement03>().currentMoveSpeed, ForceMode.Impulse);
            Destroy(collision.gameObject);
            Invoke("Kill", 3);
        }
    }

    void Kill()
    {
        gameStatesA.EndGame("You got impaled", -15);
    }
}
