using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MouseDoor : MonoBehaviour
{
    public GameObject virtualCam;
    [SerializeField] Transform toRotate;
    [SerializeField] float openAngle = 150f;
    [SerializeField] float openSpeed = 50f;
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
            toRotate.localRotation = Quaternion.RotateTowards(toRotate.localRotation, Quaternion.Euler(0, openAngle, 0), Time.deltaTime * openSpeed);
        }
    }

    void OpenDoor()
    {
        opening = true;
    }
}
