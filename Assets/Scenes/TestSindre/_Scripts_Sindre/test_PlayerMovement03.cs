using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_PlayerMovement03 : MonoBehaviour
{
    public PlayerStatesMovements psm;
    public test_GroundCheck gc;
    public test_ClimbChecker cc;
    public Transform camTrans;

    //Move atributes//
    public float walkSpeed = 10;
    public float runSpeed = 20;
    public float smellSpeed = 6;
    public float rotationSpeed = 10;

    //Jump attributes//
    public float jumpHeight = 5f;
    public float jumpTime = 1f;
    public float gravityMultiplier = 10f;

    //Climbing attributes//
    public float climbStartSpeed = 5;
    public float climbTime = 1;


    //States//
    private bool _isMoving;
    private bool _isRunning;
    private bool _isSmelling;
    private bool _isEating;
    private bool _isJumping;
    private bool _isClimbing;
    private bool _isGrounded;
    private bool _isLocked;

    private float horInput, vertInput;
    private Rigidbody rb;
    private Vector3 moveDir;
    private float currentMoveSpeed;
    private float currentJumpTime;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        SetGetStates();
        SetSpeed();
        SetDirection();
        InputCheck();
        RotatePlayer();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void InputCheck()
    {
        horInput = Input.GetAxis("Horizontal");
        vertInput = Input.GetAxis("Vertical");
        if (horInput != 0 || vertInput != 0) _isMoving = true; else _isMoving = false;
        if (Input.GetKey(KeyCode.LeftShift)) _isRunning = true; else _isRunning = false;
        if (_isJumping) currentJumpTime = Mathf.MoveTowards(currentJumpTime, jumpTime, Time.deltaTime);
        if (_isGrounded) currentJumpTime = 0;
        if (Input.GetKey("space") && currentJumpTime < jumpTime) _isJumping = true; else _isJumping = false;
        if (Input.GetKey("f")) _isSmelling = true; else _isSmelling = false;
    }

    void SetGetStates()
    {
        //Get states
        _isGrounded = gc.isGrounded;
        _isLocked = psm.lockController;
        _isClimbing = cc.canClimb;

        //Set states
        psm.isMoving = _isMoving;
        psm.isRunning = _isRunning;
        psm.isSmelling = _isSmelling;
        psm.isEating = _isEating;
        psm.isJumping = _isJumping;
    }

    void SetDirection()
    {
        if (_isClimbing)
        {
            moveDir = Vector3.up;
        }
        else if (_isJumping)
        {
            moveDir = transform.forward + new Vector3(0, 1, 0);
        }
        else if (_isMoving)
        {
            moveDir = transform.forward;
        }
        else
        {
            moveDir = Vector3.zero;
        }
    }

    void SetSpeed()
    {
        if (_isClimbing && _isRunning)
        {
            currentMoveSpeed = climbStartSpeed;
        }
        else if (_isMoving && !_isRunning && !_isSmelling)
        {
            currentMoveSpeed = walkSpeed;
        }
        else if (_isMoving && _isRunning && !_isSmelling)
        {
            currentMoveSpeed = runSpeed;
        }
        else if (_isMoving && !_isSmelling)
        {
            currentMoveSpeed = smellSpeed;
        }
        else
        {
            currentMoveSpeed = 0;
        }

    }

    void MovePlayer()
    {
        rb.velocity = moveDir * currentMoveSpeed;

        if (!_isGrounded && !_isJumping && !_isClimbing)
        {
            rb.velocity += Vector3.down * gravityMultiplier;
        }
    }

    void RotatePlayer()
    {
        if (_isMoving)
        {
            float angle = Mathf.Atan2(horInput, vertInput) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle + camTrans.eulerAngles.y, Vector3.up), Time.deltaTime * rotationSpeed);
        }
    }
}
