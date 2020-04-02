using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    [Header("Can be destroyed by:")]
    public bool heavy;      //True if heavy objects can destroy this object
    public bool sharp;      //True if sharp objects can destroy this object
    public bool flammable;  //True if burning objects can destroy this object

    [Header("Minimum velocity:")]
    public float heavyVel;  //Minimum velocity for heavy objects to destroy this object
    public float sharpVel;  //Minimum velocity for sharp objects to destroy this object
}
