using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowAim : MonoBehaviour
{
    public Transform camTrans;

    // Update is called once per frame
    void Update()
    {
        transform.forward = camTrans.forward;
    }
}
