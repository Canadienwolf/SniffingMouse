using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulatedBounceAndTilt : MonoBehaviour
{
    public PlayerMovement playerMovement;       //The movement script for the player object

    public float maxTilt = 5;
    public float maxHeight = 1f;
    public float bounceSpeed = 5f;

    private float tiltSpeed;
    private float currentTilt;

    private float currentHeight;
    private float jumpTime;

    // Update is called once per frame
    void Update()
    {
        //Slightly tilting the object based on the players current speed
        tiltSpeed = maxTilt * 1.8f;
        currentTilt = Mathf.MoveTowards(currentTilt, playerMovement._currentSpeed / playerMovement.runSpeed * maxTilt, Time.deltaTime * tiltSpeed);
        transform.localRotation = Quaternion.Euler(currentTilt, transform.rotation.y, 0);

        //Making the body of the player simulate a small bounce based on the players current speed
        if (playerMovement._isGrounded)
        {
            jumpTime += Time.deltaTime * playerMovement._currentSpeed;
            currentHeight = Mathf.MoveTowards(currentHeight, Mathf.Sin(jumpTime) * (maxHeight * playerMovement._currentSpeed / playerMovement.runSpeed), Time.deltaTime * bounceSpeed);
            if (jumpTime >= Mathf.PI) jumpTime = 0;
            transform.position = new Vector3(transform.position.x, currentHeight + playerMovement.gameObject.transform.position.y, transform.position.z);
        }
    }
}
