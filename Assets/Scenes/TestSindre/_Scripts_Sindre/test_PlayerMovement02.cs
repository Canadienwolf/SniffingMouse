using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_PlayerMovement02 : MonoBehaviour
{
    public PlayerStatesMovements psm;
    public test_GroundCheck gc;
    public test_ClimbChecker cc;
    public Transform camTrans;

    public float walkSpeed = 2;
    public float runSpeed = 3;
    public float smellingSpeed = 1;
    public float rotationSpeed = 10;
    public float jumpForce = 5f;
    public float initalJumpForce = 0.5f;
    public float wallJumpForce = 10f;
    public float jumpTime = .5f;
    public float wallRunLength = 5f;
    public float wallRunTime = .5f;
    public float gravityMultiplier = 5f;
    [Range(0, 1)]
    public float airControl = 0.5f;
    public float climbFalloff = 1f;

    private float vertInput, horInput;
    private bool jumpInput, runInput, smellInput;
    private bool isMoving, isRunning, isClimbing;
    [HideInInspector] public float currentSpeed;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
            Jump();
            WallJump();
        }
    }

    void FixedUpdate()
    {
        if (!psm.lockController)
        {
            if(isMoving) MovePlayer();
        }
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    //My methods
    //------------------------------------------------------------

    void InputCheck()
    {
        vertInput = Input.GetAxis("Vertical");
        horInput = Input.GetAxis("Horizontal");
        //if (cc.canClimb) rb.useGravity = false; else rb.useGravity = true;
        if ((Input.GetKeyDown("space") || Input.GetButtonDown("Jump")) && cc.canClimb) { isClimbing = true; Invoke("StopWallJump", wallRunTime); }
        else if ((Input.GetKeyDown("space") || Input.GetButtonDown("Jump")) && gc.isGrounded) StartJump();
        jumpInput = Input.GetKey("space");
        jumpInput = Input.GetButton("Jump");
        if (Input.GetKeyUp("space") || Input.GetButtonUp("Jump")) { jumpCounter = jumpTime + 1; StopWallJump(); }
        runInput = Input.GetKey(KeyCode.LeftShift) || Input.GetAxis("Run") != 0 ? true : false;
        if (Input.GetKey("f") || Input.GetButton("Smell")) smellInput = true; else smellInput = false;

        isMoving = vertInput != 0 || horInput != 0 ? true : false;
        isRunning = runInput && isMoving ? true : false;

        psm.isMoving = isMoving;
        psm.isRunning = isRunning;
        psm.isGrounded = gc.isGrounded;
        psm.isSmelling = smellInput;
        if (!psm.isJumping && !gc.isGrounded && rb.useGravity) rb.AddForce(Vector3.down * gravityMultiplier);
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
        if (smellInput && gc.isGrounded)
        {
            rb.MovePosition(transform.position + transform.forward * Time.deltaTime * smellingSpeed);
        }
        else
        {
            if (gc.isGrounded)
            {
                rb.MovePosition(transform.position + transform.forward * Time.deltaTime * currentSpeed);
            }
            else
            {
                rb.MovePosition(transform.position + transform.forward * Time.deltaTime * currentSpeed * airControl);
            }
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

    float jumpCounter;
    void StartJump()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * initalJumpForce, ForceMode.Impulse);
    }

    void Jump()
    {
        if (!isClimbing)
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
    }

    void WallJump()
    {
        if (isClimbing)
        {
            rb.useGravity = false;
            rb.velocity = Vector3.up * wallJumpForce;
        }
    }

    void StopWallJump()
    {
        rb.useGravity = true;
        isClimbing = false;
    }
}
