using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropShadow : MonoBehaviour
{
    void Update()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, Vector3.down, out hitInfo, 1000))
        {
            transform.GetChild(0).transform.position = hitInfo.point + new Vector3(0, 0.01f, 0);
        }
    }
}
