using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnTrigger : MonoBehaviour
{
    public GameObject[] objects;

    private void Start()
    {
        Active(false);
    }

    void OnTriggerEnter(Collider other)
    {
        Active(true);
    }

    void Active(bool active)
    {
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(active);
        }
    }
}
