using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_OpenDoorOn : MonoBehaviour
{
    public float openAngle = 90;
    public float openSpeed = 5f;
    public GameObject openOnDestroy;
    public bool useOnDestroy = true;

    private bool opening;

    // Update is called once per frame
    void Update()
    {
        if ((openOnDestroy == null && useOnDestroy) || opening)
        {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(0, openAngle, 0), Time.deltaTime * openSpeed);
        }
    }

    public void Opening()
    {
        opening = true;
    }
}
