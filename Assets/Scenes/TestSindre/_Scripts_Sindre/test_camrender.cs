using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class test_camrender : MonoBehaviour
{
    public LayerMask defaultRender;
    public LayerMask cloudRender;
    public Color backgroundSmellColor;
    public PlayerStatesMovements psm;

    private Color standardColor;

    private void Start()
    {
        standardColor = GetComponent<Camera>().backgroundColor;
        GetComponent<Camera>().cullingMask = defaultRender;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("f"))
        {
            GetComponent<Camera>().cullingMask = cloudRender;
            GetComponent<Camera>().backgroundColor = backgroundSmellColor;
            if(psm.isGrounded)
                psm.lockController = true;
            psm.isSmelling = true;
        }
        else
        {
            GetComponent<Camera>().cullingMask = defaultRender;
            GetComponent<Camera>().backgroundColor = standardColor;
            
        }

        if (Input.GetKeyUp("f"))
        {
            psm.lockController = false;
            psm.isSmelling = false;
        }
    }
}
