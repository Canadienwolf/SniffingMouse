using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketBehavior : MonoBehaviour
{
    public PlayerStatesMovements psm;
    public GameObject drowingBobbles;
    public float struggleFrequncy = 1;
    public float offsetHeight = 1;
    public float height = 1;
    public float speed = 10f;
    public ChangeEyes eyes;

    private Transform player;
    private bool drowning;
    private Vector3 hitPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (drowning)
        {
            player.position = Vector3.MoveTowards(player.position, new Vector3(0, Mathf.Sin(Time.time * struggleFrequncy) * height, 0) + hitPoint + new Vector3(0, offsetHeight, 0), Time.deltaTime * speed);
            player.localRotation = Quaternion.RotateTowards(player.localRotation, Quaternion.Euler(-70, player.localRotation.y, 0), Time.deltaTime * 80/2);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.transform;
            psm.lockController = true;
            eyes.Change();
            //other.transform.localRotation = Quaternion.Euler(-45, other.transform.localRotation.y, 0); 
            drowning = true;
            hitPoint = other.transform.position;
            GameObject db = Instantiate(drowingBobbles, player.position + new Vector3(0, 1, 0), Quaternion.identity);
            db.transform.parent = player;
        }
    }
}
