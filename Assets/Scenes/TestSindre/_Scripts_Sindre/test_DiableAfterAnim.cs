using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_DiableAfterAnim : MonoBehaviour
{
    public PlayerStatesMovements psm;
    public GameMangerScript gms;
    public UFO_Behaviour ufoB;
    public float startTime = 6f;

    private void Start()
    {
        gms.gameStates.timer = startTime;
        Invoke("LateStart", 0.1f);
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
            DisableCam();
    }

    void LateStart()
    {
        psm.lockController = true;
    }

    void DisableCam()
    {
        psm.lockController = false;
        gms.gameStates.timer = gms.time;
        ufoB.timeLeft.maxValue = gms.time;
        gameObject.SetActive(false);
    }
}
