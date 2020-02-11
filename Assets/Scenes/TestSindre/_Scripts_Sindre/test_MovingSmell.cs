using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_MovingSmell : MonoBehaviour
{
    public float circleTime = 5f;
    public float distFromCenter = 3f;
    public float rotationSpeed = 10f;
    public float moveSpeed = 3f;
    public float snakeMoveSpeed = 5f;
    public float snakeMoveLength = 1f;
    public float snakeHeightSpeed = 1f;
    public float snakeMoveHeigth = 1f;

    private float angle;
    private float speed;
    private float radius;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        speed = (2 * Mathf.PI) / circleTime;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("f") || Input.GetButton("Smell"))
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position + new Vector3(0, 1, 0), Time.deltaTime * moveSpeed);
        }
        else
        {
            angle += speed * Time.deltaTime;
            radius = distFromCenter + MoveSin(snakeMoveSpeed, snakeMoveLength);
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(Mathf.Cos(angle) * radius, snakeMoveHeigth/2 + MoveSin(snakeHeightSpeed, snakeMoveHeigth/ 2), Mathf.Sin(angle) * radius), Time.deltaTime * moveSpeed);
        }
    }

    float MoveSin(float speed, float length)
    {
        float returnValue;
        returnValue = (Mathf.Sin(Time.time * speed) * (length));
        return returnValue;
    }
}
