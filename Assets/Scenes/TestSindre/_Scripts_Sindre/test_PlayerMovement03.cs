using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_PlayerMovement03 : MonoBehaviour
{
    public PlayerStatesMovements psm;
    public test_GroundCheck gc;
    public test_ClimbChecker cc;
    public Transform camTrans;

    //States//
    private bool _isMoving;
    private bool _isRunning;
    private bool _isSmelling;
    private bool _isJumping;
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
        psm.SetFloats();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnDisable()
    {
        psm.ResetMoveStates();
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
        if (_isJumping) currentJumpTime = Mathf.MoveTowards(currentJumpTime, psm.jumpTime, Time.deltaTime);
        if (Input.GetKey("space") && currentJumpTime < psm.jumpTime && !_isClimbing) _isJumping = true; else _isJumping = false;
        if (Input.GetKeyUp("space") && !gc.isGrounded) currentJumpTime = psm.jumpTime;
        if (Input.GetKey("f")) _isSmelling = true; else _isSmelling = false;
    }

    void SetGetStates()
    {
        //Get states
        _isGrounded = gc.isGrounded;
        _isLocked = psm.lockController;
        _canClimb = cc.canClimb;
        if (_canClimb && _isRunning && currentClimbTime < psm.climbTime - 0.1f) _isClimbing = true; else _isClimbing = false;
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
                currentMoveSpeed = psm.climbSpeed;
            }
            else
            {
                currentClimbTime = Mathf.MoveTowards(currentClimbTime, psm.climbTime, Time.deltaTime);
            }
        }
        else if (_isMoving && !_isRunning && !_isSmelling)
        {
            currentMoveSpeed = Mathf.MoveTowards(currentMoveSpeed, psm.walkSpeed, Time.deltaTime * psm.walkAcceleration);
        }
        else if (_isMoving && _isRunning && !_isSmelling)
        {
            currentMoveSpeed = Mathf.MoveTowards(currentMoveSpeed, psm.runSpeed, Time.deltaTime * psm.runAcceleration);
        }
        else
        {
            currentMoveSpeed = Mathf.MoveTowards(currentMoveSpeed, 0, Time.deltaTime * psm.fallOffSpeed);
        }
    }

    void MovePlayer()
    {
        rb.velocity = moveDir * currentMoveSpeed;
        rb.velocity += Vector3.up * currentAirVel;

        if ((!_isGrounded && !_isJumping && !_isClimbing) || (_isSmelling && !_isGrounded))
        {
            currentAirVel = Mathf.MoveTowards(currentAirVel, -psm.gravityMultiplier, Time.deltaTime * psm.gravityMultiplier * 2);
        }
        else if (_isJumping)
        {
            if (_isGrounded)
            {
                currentAirVel = psm.jumpSpeed;
            }
            else
            {
                currentAirVel = Mathf.MoveTowards(currentAirVel, 0, Time.deltaTime * psm.jumpSpeed / psm.jumpTime);
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
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle + camTrans.eulerAngles.y, Vector3.up), Time.deltaTime * psm.rotationSpeed);
        }
    }
}
