using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

/*
    Types of traps:
    tsf = Trap Spawner Floor
    tsw = Trap Spawner Wall
    tsr = Trap Spawner Roof

    The traps spawners on the floor has to have the tag "TrapSpawnerFloor" to be working with this script.
    
*/
public class TrapsController : MonoBehaviour
{

    //Private
    
    
    //Public
    public GameObject[] trapsFloor; //Traps that can be placed on the floor and will be working. 
    public GameObject[] tsf;    //TSF = Trap Spawner Floor
    
    
    // Start is called before the first frame update
    void Start()
    {
        tsf = GameObject.FindGameObjectsWithTag("TrapSpawnerFloor");
        
        TrapPopulator();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TrapPopulator() //Check if all the traps are populated, if not, then get a trap there.
    {
        for (int i = 0; i < tsf.Length; i++)
        {
            if (gameObject.transform.childCount == 0) //empty
            {
                GameObject go = Instantiate(trapsFloor[Random.Range(0, trapsFloor.Length)],tsf[i].transform.position, Quaternion.identity);

                go.transform.parent = tsf[i].transform;
            }
        }
    }
    
}
