using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_climbing : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float climbFalloff = 2f;
    public test_GroundCheck gc;

    private Rigidbody rb;
    private float horInput;
    [SerializeField] private bool running, colWall;
    private float currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        InputChecker();


        if(rb.useGravity)
            rb.AddForce(Vector3.down * 100);
    }

    void InputChecker()
    {
        horInput = Input.GetAxis("Horizontal");
        running = Input.GetKey(KeyCode.LeftShift);
    }

    void MovePlayer()
    {
        //rb.MovePosition(transform.position + transform.right * Time.deltaTime * walkSpeed * horInput);
        //transform.position += transform.right * Time.deltaTime * walkSpeed * horInput;
        if (running && colWall)
        {
            rb.velocity = transform.up * currentSpeed * Mathf.Abs(horInput);
            rb.useGravity = false;
            currentSpeed -= Time.deltaTime * climbFalloff;
            if (currentSpeed <= 0)
            {
                colWall = false;
            }
        }
        else
        {
            rb.velocity = transform.right * currentSpeed * horInput;
            rb.useGravity = true;
            currentSpeed = walkSpeed;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "Player")
        {
            colWall = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player")
        {
            colWall = false;
        }
    }
}
