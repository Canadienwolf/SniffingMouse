using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PickupSystem))]
public class Display_Pickibal : MonoBehaviour
{
    public GameObject display;

    private void Update()
    {
        if (GetComponent<PickupSystem>()._pickedUp)
            display.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickable" && !GetComponent<PickupSystem>()._pickedUp)
        {
            display.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Pickable")
        {
            display.SetActive(false);
        }
    }
}
