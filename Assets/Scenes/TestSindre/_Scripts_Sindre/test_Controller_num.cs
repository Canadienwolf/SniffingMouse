using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_Controller_num : MonoBehaviour
{
    test_InputChecker inputCheck = new test_InputChecker();

    [SerializeField] float walkSpeed = 5f;
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float rotateSpeed = 50f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float jumpTime = 2f;
    [SerializeField] Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        test_InputChecker.isGrounded = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inputCheck.IsMoving())
        {
            if (inputCheck.Running())
            {
                MoveForwad(runSpeed);
            }
            else
            {
                MoveForwad(walkSpeed);
            }
        }
        Jump();
    }

    void MoveForwad(float speed)
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        RotatePlayer();
    }

    void RotatePlayer()
    {
        Vector3 dir = inputCheck.MoveDirection();
        float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle + cam.transform.eulerAngles.y, Vector3.up), Time.deltaTime * rotateSpeed);
    }

    void Jump()
    {
        if (inputCheck.JumpStart())
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce * GetComponent<Rigidbody>().mass, ForceMode.Impulse);
        }
        else if (!test_InputChecker.isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.down * GetComponent<Rigidbody>().mass * 9.81f);
        }
    }
}
