using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoombaButton : MonoBehaviour
{
    public float resetTime = 3f;
    public ParticleSystem suckIn;

    private RoombaVisuals rv;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        rv = transform.parent.gameObject.GetComponent<RoombaVisuals>();
        startPos = transform.localPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Pickable")
        {
            rv.isOff = true;
            transform.localPosition = new Vector3(0, 1, 0);
            suckIn.Stop();
            Invoke("RestartRoomba", resetTime);
        }
    }

    void RestartRoomba()
    {
        rv.isOff = false;
        transform.localPosition = startPos;
        suckIn.Play();
    }
}
