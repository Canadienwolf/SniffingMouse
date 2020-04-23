using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDoor : MonoBehaviour
{
    float openAngle = 150f;
    float openSpeed = 50f;
    bool opening;


    // Start is called before the first frame update
    void Start()
    {
        CheeseManager.current.onFoundAllCheese += OpenDoor;
    }

    void Update()
    {
        if (opening)
        {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(0, openAngle, 0), Time.deltaTime * openSpeed);
        }
    }

    void OpenDoor()
    {
        opening = true;
    }
}
