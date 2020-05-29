using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBehavior : MonoBehaviour
{
    [SerializeField] PlayerStatesMovements psm;
    [SerializeField] float walkSpeed = 5f;
    [SerializeField] float runSpeed = 15f;
    [SerializeField] float moveDelay = 0.1f;
    [SerializeField] float jumpSpeed = 20f;
    [SerializeField] float jumpTime = .9f;
    [SerializeField] float jumpDelay = 0.1f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] float climbTime = 2f;
    [SerializeField] float rotationSpeed = 20f;
    [SerializeField] Camera cam;

    float jumpCounter;
    bool isJumping;
    bool startedMoving;
    bool isMoving;
    float climbCounter;
    bool startedClimbing, canClimb;

    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!psm.lockController)
        {
            if (InputManager.isGrounded)
                canClimb = true;
            else if (!InputManager.isClimbing)
                rb.AddForce(Vector3.down * 9.81f);

            if (InputManager.IsMoving() && !startedMoving)
            {
                startedMoving = true;
                if (InputManager.isGrounded)
                {
                    Invoke("StartMoving", moveDelay);
                }
                else
                {
                    StartMoving();
                }
            }
            if (Input.GetKeyUp("space"))
                EndMoving();

            if (InputManager.Running())
            {
                Move(runSpeed);
            }
            else if (InputManager.Climbing())
                Climb();
            else if (InputManager.IsMoving())
                Move(walkSpeed);
            else
                EndMoving();
            if (!InputManager.Climbing())
                GetComponent<Rigidbody>().useGravity = true;

            if (InputManager.Jump())
                Invoke("StartJump", jumpDelay);

            if (InputManager.isGrounded)
            {
                canClimb = true;
                climbCounter = climbTime;
            }

            if (!InputManager.Climbing())
            {
                rb.useGravity = true;
                startedClimbing = false;
                InputManager.isClimbing = false;
            }

            Jump();
            Rotate();
        }
        
    }

    void Jump()
    {
        if (isJumping)
        {
            jumpCounter = Mathf.MoveTowards(jumpCounter, 0, Time.deltaTime);
            if (jumpCounter == 0)
            {
                isJumping = false;
            }
            else
            {
                transform.Translate(Vector3.up * Time.deltaTime * jumpSpeed * jumpCounter);
            }
        }
    }

    void StartJump()
    {
        isJumping = true;
        jumpCounter = jumpTime;
    }

    void Move(float speed)
    {
        if (isMoving)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }

    void StartMoving()
    {
        isMoving = true;
    }

    void EndMoving()
    {
        isMoving = false;
        startedMoving = false;
    }

    void Rotate()
    {
        if (InputManager.IsMoving())
        {
            float angle = Mathf.Atan2(InputManager.MoveDirection().x, InputManager.MoveDirection().z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle + cam.transform.eulerAngles.y, Vector3.up), Time.deltaTime * rotationSpeed);
        }
    }

    void Climb()
    {
        if (canClimb)
        {
            if (!startedClimbing)
            {
                rb.velocity = Vector3.zero;
            }
            startedClimbing = true;
            InputManager.isClimbing = true;
            rb.useGravity = false;
            transform.Translate(Vector3.up * Time.deltaTime * climbSpeed);
            climbCounter = Mathf.MoveTowards(climbCounter, 0, Time.deltaTime);
            if (climbCounter == 0)
            {
                rb.useGravity = true;
                startedClimbing = false;
                canClimb = false;
                InputManager.isClimbing = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isJumping)
        {
            isJumping = false;
        }
    }

    private void OnDisable()
    {
        InputManager.isClimbing = false;
        InputManager.isEating = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
