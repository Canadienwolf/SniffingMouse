using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEyesOnEnable : MonoBehaviour
{
    public delegate void ChangeEyes();
    public static event ChangeEyes OnChangeEyes;

    void OnEnable()
    {
        OnChangeEyes();
    }
}
