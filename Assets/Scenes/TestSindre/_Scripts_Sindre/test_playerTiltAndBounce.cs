using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_playerTiltAndBounce : MonoBehaviour
{
    public test_PlayerMovement02 cm;

    public float maxTilt = 5;
    public float maxHeight = 1f;
    public float bounceSpeed = 5f;

    private float tiltSpeed;
    private float currentTilt;
    private float desiredTilt;

    private float currentHeight;
    private float jumpTime;

    // Update is called once per frame
    void Update()
    {
        if (!cm.psm.isEating)
        {
            tiltSpeed = maxTilt * 1.8f;
            currentTilt = Mathf.MoveTowards(currentTilt, cm.currentSpeed / cm.runSpeed * maxTilt, Time.deltaTime * tiltSpeed);
            transform.localRotation = Quaternion.Euler(currentTilt, transform.rotation.y, 0);

            if (cm.gc.isGrounded)
            {
                jumpTime += Time.deltaTime * cm.currentSpeed;
                currentHeight = Mathf.MoveTowards(currentHeight, Mathf.Sin(jumpTime) * (maxHeight * cm.currentSpeed / cm.runSpeed), Time.deltaTime * bounceSpeed);
                if (jumpTime >= Mathf.PI) jumpTime = 0;
                transform.position = new Vector3(transform.position.x, currentHeight + cm.gameObject.transform.position.y, transform.position.z);
            }
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            jumpTime += Time.deltaTime * cm.currentSpeed;
            currentHeight = Mathf.MoveTowards(currentHeight, Mathf.Sin(jumpTime) * (maxHeight), Time.deltaTime);
            if (jumpTime >= Mathf.PI) jumpTime = 0;
            transform.localScale = new Vector3(1, currentHeight + transform.localScale.y / 2, 1);
        }
        
    }
}
