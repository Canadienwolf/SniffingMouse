using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ChangeEyes
{
    public EyesController.emotions emotions;

    public void Change()
    {
        GameObject.FindObjectOfType<EyesController>().EyeState = emotions;
        GameObject.FindObjectOfType<EyesController>().ChangeEyes();
    }
}
