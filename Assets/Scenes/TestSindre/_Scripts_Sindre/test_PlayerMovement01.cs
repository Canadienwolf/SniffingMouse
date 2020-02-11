using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_PlayerMovement01 : MonoBehaviour
{
    public Transform cam_trans;
    public test_GroundCheck groundCheck;
    public PlayerStatesMovements playerStates;

    [Range(1, 10)]
    public float walkSpeed = 1;
    [Range(5, 20)]
    public float runSpeed = 5;
    [Range(5, 20)]
    public float rotationSpeed = 5;
    [Range(1, 30)]
    public float jumpForce = 1f;
    [Range(0.1f, 1f)]
    public float jumpTime = 1f;
    [Range(10, 30)]
    public float fallingSpeedMultiplier = 1f;
    [Range(0, 15)]
    public float airControlForce = 1f;

    private float _horInput;
    private float _vertInput;
    [HideInInspector] public float _currentSpeed;
    [HideInInspector] public bool _isGrounded;
    private float _currentAirTime;
    private bool _isMoving;
    private bool _isRunning;
    private bool _isJumping;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();     //Getting the rigidbody
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        _isGrounded = groundCheck.isGrounded;   //Checking if the player is on the ground

        //Checking for movement inputs
        _vertInput = Input.GetAxis("Vertical");
        _horInput = Input.GetAxis("Horizontal");
        if (_vertInput != 0 || _horInput != 0) playerStates.isMoving = true; else playerStates.isMoving = false;
        if (Input.GetKey(KeyCode.LeftShift)) playerStates.isRunning = true; else playerStates.isRunning = false;

        if (!playerStates.isMoving) _currentSpeed = 0;

        if (!playerStates.lockController)
        {
            RotatePlayer();
            JumpPlayer();
        }

    }

    void FixedUpdate()
    {
        if (!playerStates.lockController)
        {
            MovePlayer();

            //Gives the player limited movement control when in the air
            if (!_isGrounded && playerStates.isMoving) rb.AddForce(transform.forward * airControlForce);
            //When the time in the air is equal to the jumptime, the player will fall faster if he jumped. The same will happen instantly if the player did not jump
            if ((playerStates.isJumping && _currentAirTime >= jumpTime) || !playerStates.isJumping)
            {
                rb.AddForce(Vector3.down * fallingSpeedMultiplier);
                playerStates.isJumping = false;
            }
        }
    }

    //--------------------------------------------------------------------------------

    //Grounded movement of the player
    //The player will always walk forward
    void MovePlayer()
    {
        if (playerStates.isMoving && _isGrounded)
        {
            _currentSpeed = playerStates.isRunning ? runSpeed : walkSpeed;
            transform.position += (transform.right * _horInput * _currentSpeed * Time.fixedDeltaTime) + (transform.forward * _vertInput * _currentSpeed * Time.fixedDeltaTime);
        }
    }

    //Rotating acording to the cameras position, the horizontal and vertical input
    void RotatePlayer()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x, cam_trans.eulerAngles.y, transform.rotation.z);
    }

    //Makes the player jump
    void JumpPlayer()
    {
        if (Input.GetKeyDown("space") && _isGrounded)
        {
            playerStates.isJumping = true;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            if (_vertInput != 0 || _horInput != 0) rb.AddForce(transform.forward * _currentSpeed * 0.5f, ForceMode.Impulse);
        }
        //Counts the time the player is in the air
        if (!_isGrounded) _currentAirTime += Time.deltaTime; else _currentAirTime = 0;
    }
}
