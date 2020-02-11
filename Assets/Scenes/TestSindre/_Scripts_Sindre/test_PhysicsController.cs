using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_PhysicsController : MonoBehaviour
{
    public Transform camTransform;
    public test_GroundCheck groundCheck;

    public float walkForce = 5;
    public float runForce = 10;
    public float moveAcceleration = 5;
    public float rotationSpeed = 5;
    public float jumpForce = 5;
    public float jumpTime = 0.2f;
    public float gravityMultiplier = 5;
    public float airMoveForce = 5;

    [HideInInspector] public float currentForce;
    [HideInInspector] public Rigidbody rb;

    private Vector3 moveDirection;
    private float _vert, _hor;
    private float _currentAirTime;
    private bool _jumpPressed, _isRunning;
    private bool _isMoving;
    private bool _isCollidingInAir;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        InputCheck();
    }

    void FixedUpdate()
    {
        if (_isMoving && !_isCollidingInAir) MovePlayer();
        if ((_isMoving && groundCheck.isGrounded) || (!groundCheck.isGrounded)) RotatePlayer();
        if (_jumpPressed) Jump();
        if (!groundCheck.isGrounded) rb.AddForce(Vector3.down * gravityMultiplier);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!groundCheck.isGrounded) _isCollidingInAir = true; else _isCollidingInAir = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!groundCheck.isGrounded) _isCollidingInAir = true; else _isCollidingInAir = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        _isCollidingInAir = false;
    }

    //-------------------------------------------------------------------------------------

    void InputCheck()
    {
        _vert = Input.GetAxis("Vertical");
        _hor = Input.GetAxis("Horizontal");
        _jumpPressed = Input.GetKey("space");
        _isRunning = Input.GetKey(KeyCode.LeftShift);

        if (_vert != 0 || _hor != 0) _isMoving = true; else _isMoving = false;
        if (groundCheck.isGrounded) _currentAirTime = 0;
    }

    void MovePlayer()
    {
        moveDirection = (camTransform.right * _hor) + (camTransform.forward * _vert);
        moveDirection.y = rb.velocity.y;

        currentForce = _isRunning ? Mathf.MoveTowards(currentForce, runForce, Time.deltaTime * moveAcceleration) : Mathf.MoveTowards(currentForce, walkForce, Time.deltaTime * moveAcceleration);

        rb.velocity = groundCheck.isGrounded ? new Vector3(moveDirection.x * currentForce, rb.velocity.y, moveDirection.z * currentForce) : new Vector3(moveDirection.x * airMoveForce, rb.velocity.y, moveDirection.z * airMoveForce);
    }

    void RotatePlayer()
    {
        float angle = Mathf.Atan2(rb.velocity.x, rb.velocity.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.up), Time.deltaTime * rotationSpeed);
    }

    void Jump()
    {
        _currentAirTime += Time.deltaTime;
        if (_currentAirTime < jumpTime) rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    }
}
