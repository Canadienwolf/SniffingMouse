using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesController : MonoBehaviour
{
    public enum emotions { };

    void Awake()
    {
        ChangeEyesOnEnable.OnChangeEyes += ChangeEyes;
    }

    void ChangeEyes()
    {

    }
}
