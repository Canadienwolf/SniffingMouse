using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerST Mov", menuName = "PlayerSt Movement")]
public class PlayerStatesMovements : ScriptableObject
{
    //checking if the player is walking
    public bool isMoving;

    //checking if the player is walking
    public bool isJumping;

    //checking if the player is walking
    public bool isRunning;

    public bool isEating;

    public bool isGrounded;

    //for locking the movements controller
    public bool lockController;
}
