using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowAim : MonoBehaviour
{
    public Transform camTrans;
    public float angleTreshold = 30;

    private float angle;

    // Update is called once per frame
    void Update()
    {
        angle = Vector3.Angle(camTrans.forward, transform.parent.forward);
        if (Mathf.Abs(angle) < angleTreshold)
            transform.forward = camTrans.forward;
    }
}
