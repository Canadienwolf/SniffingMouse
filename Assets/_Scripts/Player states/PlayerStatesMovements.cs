using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerST Mov", menuName = "PlayerSt Movement")]
public class PlayerStatesMovements : ScriptableObject
{
    public bool isMoving;
    public bool isJumping;
    public bool isRunning;
    public bool isEating;
    public bool isSmelling;
    public bool isGrounded;
    public bool isClimbing;
    public bool caughtBySmell;
    public bool lockController;

    public float walkSpeed = 10;
    public float walkAcceleration = 20;
    public float jumpSpeed = 18;
    public float jumpTime = 0.5f;
    public float runSpeed = 20;
    public float runAcceleration = 40;
    public float climbSpeed = 10;
    public float climbTime = 1.1f;
    public float gravityMultiplier = 20f;
    public float rotationSpeed = 10;
    public float fallOffSpeed = 40;

    private float _startWalkSpeed;
    private float _startWalkAcceleration;
    private float _startJumpSpeed;
    private float _startJumpTime;
    private float _startRunSpeed;
    private float _startRunAcceleration;
    private float _startClimbSpeed;
    private float _startClimbTime;
    private float _startGravityMultiplier;
    private float _startRotationSpeed;
    private float _startFallOffSpeed;



    public void ResetMoveStates()
    {
        isMoving = false;
        isJumping = false;
        isRunning = false;
        isEating = false;
        isSmelling = false;
        isGrounded = false;
        isClimbing = false;
        caughtBySmell = false;
        lockController = false;
        ResetFloats();
    }

    public void SetFloats()
    {
        _startWalkSpeed = walkSpeed;
        _startWalkAcceleration = walkAcceleration;
        _startJumpSpeed = jumpSpeed;
        _startJumpTime = jumpTime;
        _startRunSpeed = runSpeed;
        _startRunAcceleration = runAcceleration;
        _startClimbSpeed = climbSpeed;
        _startClimbTime = climbTime;
        _startGravityMultiplier = gravityMultiplier;
        _startRotationSpeed = rotationSpeed;
        _startFallOffSpeed = fallOffSpeed;
    }

    public void ResetFloats()
    {
        walkSpeed = _startWalkSpeed;
        walkAcceleration = _startWalkAcceleration;
        jumpSpeed = _startJumpSpeed;
        jumpTime = _startJumpTime;
        runSpeed = _startRunSpeed;
        runAcceleration = _startRunAcceleration;
        climbSpeed = _startClimbSpeed;
        climbTime = _startClimbTime;
        gravityMultiplier = _startGravityMultiplier;
        rotationSpeed = _startRotationSpeed;
        fallOffSpeed = _startFallOffSpeed;
    }
}
