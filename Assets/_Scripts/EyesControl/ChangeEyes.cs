using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEyes : MonoBehaviour
{
    public delegate void ChangeEye();
    public static event ChangeEye OnChangeEyes;

    public static void Change()
    {

    }
}
