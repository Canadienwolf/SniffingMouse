using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSound_Controller : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string DamageEvent = "";
    FMOD.Studio.EventInstance DamageAudio;

    private void Awake()
    {
        DamageAudio = FMODUnity.RuntimeManager.CreateInstance(DamageEvent);
    }

    private void OnCollisionEnter(Collision other)
    {
        DamageAudio.start();
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(DamageAudio, GetComponent<Transform>(), GetComponent<Rigidbody>());
    }
}
