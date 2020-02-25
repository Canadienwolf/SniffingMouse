using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PickupSystem : MonoBehaviour
{
    //public
    public Transform heldItemTransform;
    public GameObject temparent;
    public GameObject pickableObject;
    public float maxPower = 50f;
    public float powerAcceleration = 100f;

    //private
    public bool _pickedUp = false;
    private float power;
    private bool _canThrow;

    // Update is called once per fr%%ame
    void Update()
    {

        
        if ((Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("Pick")) && pickableObject != null)
        {
            _pickedUp = !_pickedUp;

            if (_pickedUp)
            {
                
                pickableObject.transform.parent = heldItemTransform.transform;
                pickableObject.transform.position = heldItemTransform.transform.position;
                pickableObject.GetComponent<Rigidbody>().isKinematic = true;
                pickableObject.transform.localPosition = new Vector3(0, 0, 0);
                pickableObject.transform.localRotation = Quaternion.identity;
                PickbleColliders(false);
                
                _pickedUp = true;
            }
            else if(_pickedUp == false)
            {
                
                pickableObject.transform.parent = null;
                pickableObject.GetComponent<Rigidbody>().isKinematic = false;
                PickbleColliders(true);
                
                _pickedUp = false;
            }
            
        }
        
        
        if ((Input.GetMouseButton(0) || Input.GetButton("Throw")) && !_canThrow)
        {
            power = Mathf.MoveTowards(power, maxPower, Time.deltaTime * powerAcceleration);
        }

        if ((Input.GetMouseButtonUp(0) || Input.GetButtonUp("Throw")))
        {
            if (!_canThrow && pickableObject != null)
            {
                pickableObject.transform.parent = null;
                pickableObject.GetComponent<Rigidbody>().isKinematic = false;
                pickableObject.GetComponent<Rigidbody>().AddForce(heldItemTransform.forward * power, ForceMode.Impulse);
                PickbleColliders(true);
                pickableObject = null;
                _pickedUp = false;
            }
            power = 0;
            _canThrow = false;
        }

        if (Input.GetButtonDown("Cancel") || Input.GetMouseButtonDown(1))
        {
            power = 0f;
            print(power);
            _canThrow = true;
        }
        
        
    }

    private void OnTriggerEnter(Collider Pickable)
    {
        if (Pickable.CompareTag("Pickable") && !_pickedUp)
        {
            pickableObject = Pickable.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!_pickedUp)
        {
            pickableObject = null;
        }
    }

    void PickbleColliders(bool idx)
    {
        if (pickableObject != null)
        {
            foreach (Collider c in pickableObject.GetComponents<Collider>())
            {
                c.enabled = idx;
            }
        }
    }
}
