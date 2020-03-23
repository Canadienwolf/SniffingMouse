using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoombaVisuals : MonoBehaviour
{
    public float speed = 1f;
    public float rotSpeed = 10f;
    public float minAngle = -180f;
    public float maxAngle = 180f;
    public bool isOff = false;
    public PlayerStatesMovements psm;

    [Header("Death Attributes")]
    public float menuDelay = 3f;
    public ParticleSystem suckPartical;

    private float angleToRot;
    private bool rotating;

    // Start is called before the first frame update
    void Start()
    {
        SetAngle();
    }

    // Update is called once per frame
    void Update()
    {
        rotating = Quaternion.Angle(Quaternion.Euler(0, angleToRot, 0), transform.localRotation) == 0 ? false : true;
        if (!isOff)
        {
            if (rotating)
                Rotating();
            else
                ForwardMovement();
        }

    }

    void ForwardMovement()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void Rotating()
    {
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(0, angleToRot, 0), Time.deltaTime * rotSpeed);
    }

    void SetAngle()
    {
        float rand = Random.Range(minAngle, maxAngle);
        angleToRot = transform.localRotation.y + rand;
    }

    void Lose()
    {
        GameMangerScript.EndGame("You got sucked!", (-15));
    }

    void SuckIn(GameObject player)
    {
        Instantiate(suckPartical, player.transform.position, player.transform.rotation);
        player.transform.GetChild(0).transform.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            SetAngle();
            rotating = true;
            transform.position += transform.forward * -0.2f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isOff)
        {
            psm.lockController = true;
            SuckIn(other.gameObject);
            Invoke("Lose", menuDelay);
        }
    }
}
