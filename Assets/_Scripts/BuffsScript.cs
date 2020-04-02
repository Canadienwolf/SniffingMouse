using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffsScript : MonoBehaviour
{
    //help variables!
    //random numbers used in order buff/debuff (repetitive 0.3/0.5 numbers just for debuffs))!
    private float []randNum = {0.1f,0.3f,2f,.5f,3f,0.1f,0.3f,0.5f,4f,5f,6f};
    public PlayerStatesMovements plStates;

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "RuningBuff":
                this.gameObject.GetComponent<test_PlayerMovement03>().multiplier = randNum[Random.Range(5,randNum.Length)];
                this.gameObject.GetComponent<test_PlayerMovement03>().timer = Random.Range(15, 25);
                plStates.runSpeed *= this.gameObject.GetComponent<test_PlayerMovement03>().multiplier;
                plStates.runAcceleration *= this.gameObject.GetComponent<test_PlayerMovement03>().multiplier;
                Destroy(collision.gameObject);
                break;

            case "JumpingBuff":
                this.gameObject.GetComponent<test_PlayerMovement03>().multiplier = randNum[Random.Range(5,randNum.Length)];
                this.gameObject.GetComponent<test_PlayerMovement03>().timer = Random.Range(15, 25);
                plStates.jumpSpeed *= this.gameObject.GetComponent<test_PlayerMovement03>().multiplier;
                plStates.jumpTime *= this.gameObject.GetComponent<test_PlayerMovement03>().multiplier;
                Destroy(collision.gameObject);
                break;

            case "WalkingBuff":
                this.gameObject.GetComponent<test_PlayerMovement03>().multiplier = randNum[Random.Range(0,4)];
                this.gameObject.GetComponent<test_PlayerMovement03>().timer = Random.Range(15, 25);
                plStates.walkSpeed *= this.gameObject.GetComponent<test_PlayerMovement03>().multiplier;
                plStates.walkAcceleration *= this.gameObject.GetComponent<test_PlayerMovement03>().multiplier;
                Destroy(collision.gameObject);
                break;

            case "ClimbingBuff":
                this.gameObject.GetComponent<test_PlayerMovement03>().multiplier = randNum[Random.Range(5, randNum.Length)];
                this.gameObject.GetComponent<test_PlayerMovement03>().timer = Random.Range(15, 25);
                plStates.climbSpeed *= this.gameObject.GetComponent<test_PlayerMovement03>().multiplier;
                plStates.climbTime *= this.gameObject.GetComponent<test_PlayerMovement03>().multiplier;
                Destroy(collision.gameObject);
                break;
            case "SmellRangeBuff":
                this.gameObject.GetComponent<test_PlayerMovement03>().multiplier = randNum[Random.Range(5, randNum.Length)];
                this.gameObject.GetComponent<test_PlayerMovement03>().timer = Random.Range(15, 25);
                plStates.rotationSpeed *= this.gameObject.GetComponent<test_PlayerMovement03>().multiplier;
                Destroy(collision.gameObject);
                break;
            default:
                break;

        }

    }
   
}
