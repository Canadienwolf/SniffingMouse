using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_PlayerMovement02 : MonoBehaviour
{
    public PlayerStatesMovements psm;
    public test_GroundCheck gc;
    public Transform camTrans;

    public float walkSpeed = 2;
    public float runSpeed = 3;
    public float smellingSpeed = 1;
    public float rotationSpeed = 10;
    public float initalJumpForce = 4f;
    public float jumpForce = 3f;
    public float jumpTime = 0.5f;
    public float gravityMultiplier = 5f;
    [Range(0, 1)]
    public float airControl = 0.5f;

    private float vertInput, horInput;
    private bool jumpInput, runInput, smellInput;
    private bool isMoving, isRunning;
    [HideInInspector] public float currentSpeed;
    private float jumpCounter;
    public bool secondJump;

    // Start is called before the first frame update
    void Start()
    {
        psm.lockController = false;
        psm.isEating = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!psm.lockController)
        {
            InputCheck();
            CurrentSpeed();
            RotatePlayer();
        }
    }

    void FixedUpdate()
    {
        if (!psm.lockController)
        {
            MovePlayer();
            //Jump();
            CountJump();
        }
    }

    //My methods
    //------------------------------------------------------------

    void InputCheck()
    {
        vertInput = Input.GetAxis("Vertical");
        horInput = Input.GetAxis("Horizontal");
        //if ((Input.GetKeyDown("space") || Input.GetButtonDown("Jump")) && gc.isGrounded) StartJump();
        //jumpInput = Input.GetKey("space");
        //jumpInput = Input.GetButton("Jump");
        //if (Input.GetKeyUp("space") || Input.GetButtonUp("Jump")) jumpCounter = jumpTime + 1;
        if ((Input.GetKeyDown("space") || Input.GetButtonDown("Jump")) && !psm.lockController) Jump();
        runInput = Input.GetKey(KeyCode.LeftShift) || Input.GetAxis("Run") != 0 ? true : false;
        smellInput = Input.GetKey("f");
        smellInput = Input.GetButton("Smell");

        isMoving = vertInput != 0 || horInput != 0 ? true : false;
        isRunning = runInput && isMoving ? true : false;

        psm.isMoving = isMoving;
        psm.isRunning = isRunning;
        psm.isGrounded = gc.isGrounded;
        if (gc.isGrounded) secondJump = false;
    }

    void CurrentSpeed()
    {
        if (isMoving)
        {
            if (smellInput)
                currentSpeed = smellingSpeed;
            else if (isRunning)
                currentSpeed = runSpeed;
            else
                currentSpeed = walkSpeed;
        }
        else
            currentSpeed = 0;
    }

    void MovePlayer()
    {
        if (gc.isGrounded)
        {
            GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * Time.deltaTime * currentSpeed);
        }
        else
        {
            GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * Time.deltaTime * currentSpeed * airControl);
        }
    }

    void RotatePlayer()
    {
        if (isMoving)
        {
            float angle = Mathf.Atan2(horInput, vertInput) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle + camTrans.eulerAngles.y, Vector3.up), Time.deltaTime * rotationSpeed);
        }
    }

    void CountJump()
    {
        if (psm.isJumping && !gc.isGrounded)
        {
            jumpCounter += Time.deltaTime;
            if (jumpCounter >= jumpTime)
            {
                psm.isJumping = false;
                jumpCounter = 0;
            }
        }
        else if (!psm.isJumping && !gc.isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.down * gravityMultiplier);
        }
    }

    void Jump()
    {
        if (gc.isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * initalJumpForce, ForceMode.Impulse);
            psm.isJumping = true;
        }
        else if(!gc.isGrounded && !secondJump)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            psm.isJumping = true;
            secondJump = true;
        }
    }
    
}


/*

    void StartJump()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * initalJumpForce, ForceMode.Impulse);
    }

    void Jump()
    {
        if (jumpCounter < jumpTime && jumpInput)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
            jumpCounter += Time.deltaTime;
            psm.isJumping = true;
        }
        else
        {
            GetComponent<Rigidbody>().AddForce(Vector3.down * gravityMultiplier);
            psm.isJumping = false;
        }

        if (gc.isGrounded) jumpCounter = 0;
    }
*/
