using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathOnContact : MonoBehaviour
{

    public int timer;
    
    public PlayerStatesMovements playerstatesA;
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            playerstatesA.lockController = true;
            
            Invoke("SceneChange", timer);
        }
    }

    void SceneChange()
    {
        SceneManager.LoadScene("menu_ScoreDisplay");
    }
    
}
