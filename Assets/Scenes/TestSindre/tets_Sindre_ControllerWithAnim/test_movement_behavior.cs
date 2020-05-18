using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_movement_behavior : MonoBehaviour
{
    test_InputsAnim inputs = new test_InputsAnim();
    Rigidbody rb;

    [SerializeField] float walkSpeed = 5f;
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float rotateSpeed = 20f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float fallingForce = 9.8f;
    [SerializeField] Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        test_InputsAnim.canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (inputs.Jump())
        {
            Jump();
        }
        
        if (inputs.Walking())
        {
            Moving(walkSpeed);
        }
        else if (inputs.Running())
        {
            Moving(runSpeed);
        }
    }

    void Falling()
    {

    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void Moving(float speed)
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        RotatePlayer();
    }

    void RotatePlayer()
    {
        Vector3 dir = inputs.V2_Walking();
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle + cam.transform.eulerAngles.y, Vector3.up), Time.deltaTime * rotateSpeed);
    }
}
