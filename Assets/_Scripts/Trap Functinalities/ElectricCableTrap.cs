using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElectricCableTrap : MonoBehaviour
{

    public bool isDisarmed = false;
    
    public int timer;
    
    public PlayerStatesMovements playerstatesA;
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            if (isDisarmed == false)
            {
                playerstatesA.lockController = true;
            
                Invoke("SceneChange", timer);
            }
        }
    }

    void SceneChange()
    {
        SceneManager.LoadScene("menu_ScoreDisplay");
    }
    
}
