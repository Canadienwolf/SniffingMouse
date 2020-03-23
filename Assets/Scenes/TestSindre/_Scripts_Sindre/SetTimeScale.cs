using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTimeScale : MonoBehaviour
{
    public GameObject virtualCam;
    public bool thisTrigger;
    public float slowMotionSpeed = 0.5f;
    public float resetTime = 1f;


    private void Start()
    {
        virtualCam.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (thisTrigger && other.tag == "Player")
        {
            SetTimeTheScale(slowMotionSpeed);
            EnableObject();
            Invoke("ResetTime", resetTime);
        }
    }

    void ResetTime()
    {
        Time.timeScale = 1;
    }

    public void SetTimeTheScale(float idx)
    {
        Time.timeScale = idx;
    }

    public void EnableObject()
    {
        virtualCam.SetActive(true);
    }

    public void DisableObject(GameObject go)
    {
        go.SetActive(false);
    }
}
