using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathOnContact : MonoBehaviour
{

    public int timer = 5;

    private bool _isDisabled;
    
    public PlayerStatesMovements playerstatesA;
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            if (!_isDisabled)
            {
                playerstatesA.lockController = true;
            
                Invoke("SceneChange", timer);
            }
        }
    }

    /*
    //TODO Need to program in what will happend when the gameobject is destroyed by sharp/ heavy object.
    private void OnDestroy()
    {
        throw new NotImplementedException();
    }
    */

    void SceneChange()
    {
        SceneManager.LoadScene("menu_ScoreDisplay");
    }
    
}
