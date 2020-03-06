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
    public float walkAcceleration = 10;
    public float runSpeed = 20;
    public float runAcceleration = 10;
    public float smellSpeed = 6;
    public float smellAcceleration = 10;
    public float rotationSpeed = 10;
    public float fallOffSpeed = 20;

    //Jump attributes//
    public float jumpSpeed = 5f;
    public float jumpTime = 1f;
    public float gravityMultiplier = 10f;

    //Climbing attributes//
    public float climbSpeed = 5;
    public float climbTime = 1;


    //States//
    private bool _isMoving;
    private bool _isRunning;
    private bool _isSmelling;
    [SerializeField] private bool _isJumping;
    private bool _canClimb;
    private bool _isClimbing;
    private bool _isGrounded;
    private bool _isLocked;

    private float horInput, vertInput;
    private Rigidbody rb;
    private Vector3 moveDir;
    [HideInInspector] public float currentMoveSpeed;
    private float currentJumpTime;
    private float currentClimbTime;
    private float currentAirVel;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnDisable()
    {
        psm.lockController = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        SetGetStates();
        if (!_isLocked && !psm.isEating)
        {
            SetSpeed();
            SetDirection();
            InputCheck();
            RotatePlayer();
        }

        if (_isLocked)
        {
            currentMoveSpeed = 0;
            currentClimbTime = 0;
            currentJumpTime = 0;
            currentAirVel = 0;
            _isMoving = false;
            rb.velocity = Vector3.zero;
        }
    }

    void FixedUpdate()
    {
        if(!_isLocked)
            MovePlayer();
    }

    void InputCheck()
    {
        horInput = Input.GetAxis("Horizontal");
        vertInput = Input.GetAxis("Vertical");
        if (horInput != 0 || vertInput != 0) _isMoving = true; else _isMoving = false;
        if (Input.GetKey(KeyCode.LeftShift)) _isRunning = true; else _isRunning = false;
        if (_isGrounded) currentJumpTime = 0;
        if (_isJumping) currentJumpTime = Mathf.MoveTowards(currentJumpTime, jumpTime, Time.deltaTime);
        if (Input.GetKey("space") && currentJumpTime < jumpTime && !_isClimbing) _isJumping = true; else _isJumping = false;
        if (Input.GetKeyUp("space") && !gc.isGrounded) currentJumpTime = jumpTime;
        if (Input.GetKey("f")) _isSmelling = true; else _isSmelling = false;
    }

    void SetGetStates()
    {
        //Get states
        _isGrounded = gc.isGrounded;
        _isLocked = psm.lockController;
        _canClimb = cc.canClimb;
        if (_canClimb && _isRunning && currentClimbTime < climbTime - 0.1f) _isClimbing = true; else _isClimbing = false;
        if (_isGrounded) currentClimbTime = 0;

        //Set states
        psm.isMoving = _isMoving;
        psm.isRunning = _isRunning;
        psm.isSmelling = _isSmelling;
        psm.isJumping = _isJumping;
        psm.isClimbing = _isClimbing;
    }

    void SetDirection()
    {
        if (_isClimbing || (_isJumping && !_isMoving))
        {
            moveDir = Vector3.up;
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
        if (_isClimbing)
        {
            if (_isGrounded || _isJumping || cc.justHit)
            {
                _isJumping = false;
                currentMoveSpeed = climbSpeed;
            }
            else
            {
                currentClimbTime = Mathf.MoveTowards(currentClimbTime, climbTime, Time.deltaTime);
            }
        }
        else if (_isMoving && !_isRunning && !_isSmelling)
        {
            currentMoveSpeed = Mathf.MoveTowards(currentMoveSpeed, walkSpeed, Time.deltaTime * walkAcceleration);
        }
        else if (_isMoving && _isRunning && !_isSmelling)
        {
            currentMoveSpeed = Mathf.MoveTowards(currentMoveSpeed, runSpeed, Time.deltaTime * runAcceleration);
        }
        else if (_isMoving && _isSmelling)
        {
            currentMoveSpeed = Mathf.MoveTowards(currentMoveSpeed, smellSpeed, Time.deltaTime * smellAcceleration);
        }
        else
        {
            currentMoveSpeed = Mathf.MoveTowards(currentMoveSpeed, 0, Time.deltaTime * fallOffSpeed);
        }
    }

    void MovePlayer()
    {
        rb.velocity = moveDir * currentMoveSpeed;
        rb.velocity += Vector3.up * currentAirVel;

        if (!_isGrounded && !_isJumping && !_isClimbing)
        {
            currentAirVel = Mathf.MoveTowards(currentAirVel, -gravityMultiplier, Time.deltaTime * gravityMultiplier * 2);
        }
        else if (_isJumping)
        {
            if (_isGrounded)
            {
                currentAirVel = jumpSpeed;
            }
            else
            {
                currentAirVel = Mathf.MoveTowards(currentAirVel, 0, Time.deltaTime * jumpSpeed / jumpTime);
            }
        }
        else
        {
            currentAirVel = 0;
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
