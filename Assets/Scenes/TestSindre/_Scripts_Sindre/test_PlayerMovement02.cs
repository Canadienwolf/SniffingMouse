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
    public float jumpForce = 5f;
    public float jumpTime = .5f;
    public float doubleJumpForce = 5f;
    public float doubleJumpTime = .5f;
    public float gravityMultiplier = 5f;
    [Range(0, 1)]
    public float airControl = 0.5f;

    private float vertInput, horInput;
    private bool jumpInput, runInput, smellInput;
    private bool isMoving, isRunning;
    [HideInInspector] public float currentSpeed;
    private bool secondJump;
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
        if (Input.GetButtonDown("Jump") && !psm.lockController && gc.isGrounded) StartCoroutine(Jump(1));
        if (Input.GetButtonDown("Jump") && !psm.lockController && !gc.isGrounded && !secondJump) StartCoroutine(Jump(2));
        runInput = Input.GetKey(KeyCode.LeftShift) || Input.GetAxis("Run") != 0 ? true : false;
        if (Input.GetKey("f") || Input.GetButton("Smell")) smellInput = true; else smellInput = false;

        isMoving = vertInput != 0 || horInput != 0 ? true : false;
        isRunning = runInput && isMoving ? true : false;

        psm.isMoving = isMoving;
        psm.isRunning = isRunning;
        psm.isGrounded = gc.isGrounded;
        psm.isSmelling = smellInput;
        if (gc.isGrounded) secondJump = false;
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

    IEnumerator Jump(int idx)
    {  
        if(idx == 1)
        {
            psm.isJumping = true;
            rb.useGravity = false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            yield return new WaitForSeconds(jumpTime);
            ResetJump();
        }
        else if (idx == 2)
        {
            psm.isJumping = true;
            secondJump = true;
            rb.useGravity = false;
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(Vector3.up * doubleJumpForce, ForceMode.Impulse);
            yield return new WaitForSeconds(doubleJumpTime);
            ResetJump();
        }
    }

    void ResetJump()
    {
        rb.useGravity = true;
        psm.isJumping = false;
    }
}
