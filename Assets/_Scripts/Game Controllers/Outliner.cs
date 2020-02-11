using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outliner : MonoBehaviour
{
    
    //Toggle between standard shader and Outlined Bumper shader
    
    Shader shader01;
    Shader shader02;
    Renderer rend;
    
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        //shader01 = Shader.Find("Current");
        shader01 = GetComponent<Renderer>().material.shader;
        shader02 = Shader.Find("Outlined/Silhouetted Bumped Diffuse");
/*
        if (rend.material.shader == shader02)
        {
            rend.material.shader = shader01;
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        rend.material.shader = Input.GetKey("f") ? shader02 : shader01;
        
        /*
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (rend.material.shader == shader01)
            {
                rend.material.shader = shader02;
            }
            else
            {
                rend.material.shader = shader01;
            }
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            if (rend.material.shader == shader02)
            {
                rend.material.shader = shader01;
            }
        }
        */
    }
}
