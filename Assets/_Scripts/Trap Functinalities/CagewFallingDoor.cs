using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CagewFallingDoor : MonoBehaviour
{
    public GameObject door;
    public GameObject cage;
    public GameObject cheese;

    GameObject target;
    test_GroundCheck gc;

    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.FindObjectOfType<test_GroundCheck>();
        door.GetComponent<Rigidbody>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (door != null && target != null && cage != null)
        {
            if (door.transform.localPosition.y < 0.1f)
            {
                FindObjectOfType<DeathMusic>().dying = true;
                Invoke("Transition", 1.4f);
                Invoke("CatchPlayer", 2);
            }     
        }
        if (door == null)
        {
            cheese.transform.parent = null;
            Destroy(gameObject);
        }
    }
    void Transition()
    {
        GameObject.Find("SceneTransition").GetComponent<Animator>().SetTrigger("EndLevel");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Pickable")
        {
            if(door != null)
                door.GetComponent<Rigidbody>().isKinematic = false;
            if (other.tag == "Player")
            {
                target = other.gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            target = null;
        }
    }
}
