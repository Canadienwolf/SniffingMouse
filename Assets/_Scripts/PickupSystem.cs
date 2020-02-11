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
    public Vector3 puloc;

    
    
    //private
    private GameObject _player;
    public bool _pickedUp = false;
    private float power;
    private bool _canThrow;

    private void Awake()
    {
        _player = gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

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


                print("Picked item up");
                
                _pickedUp = true;
            }
            else if(_pickedUp == false)
            {
                
                pickableObject.transform.parent = null;
                pickableObject.GetComponent<Rigidbody>().isKinematic = false;
                PickbleColliders(true);

                print("Sindrus 10 000");
                
                _pickedUp = false;
            }
            
        }
        
        
        if ((Input.GetMouseButton(0) || Input.GetButton("Throw")) && !_canThrow)
        {
            power += Time.deltaTime * 100f;
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
        if (Pickable.CompareTag("Pickable"))
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
