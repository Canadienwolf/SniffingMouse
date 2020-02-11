using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseController : MonoBehaviour
{
    
    //Publics
    public GameObject[] cheese;    //List of all the cheese 
    
    
    // Start is called before the first frame update
    void Start()
    {
        cheese = GameObject.FindGameObjectsWithTag("Cheese");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
