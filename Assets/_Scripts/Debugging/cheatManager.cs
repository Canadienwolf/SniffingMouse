using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cheatManager : MonoBehaviour
{
    
    //Game States that controls all the numbers and mechanics for the games
    public GameStates gs;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Puts the timer of the game to 0.
        if (Input.GetKeyDown(KeyCode.F2))
        {
            gs.timer = 0;
        }
        Debug.Log(gs.won);
    }
}
