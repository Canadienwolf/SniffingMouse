using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopingPlayerMovments : MonoBehaviour
{
    public PlayerStatesMovements playerStatesB;
    private int cheeseLenght;
    private int cheeseLenghtUpd;

    private void Start()
    {
        //how many cheese in the scene when starting the game !
        cheeseLenght = GameObject.FindGameObjectsWithTag("Cheese").Length;
        //unlocking the player controls !
        playerStatesB.lockController = false;

    }

    // Update is called once per frame
    void Update()
    {
        //Updated counter of how many cheese in the scene by frame !
        cheeseLenghtUpd= GameObject.FindGameObjectsWithTag("Cheese").Length;

        //for enabling the player movement after the cheese is deleted! ( can be moved to the game manager script later on )
        if (playerStatesB.lockController==true)
        {
                if (cheeseLenghtUpd<cheeseLenght)//CheeseScript.cheeseType <= 0.0f)
                {
                    //unlocking it after finishing eating !
                    playerStatesB.isEating = false;
                    //unlocking theplayer controlls !
                    playerStatesB.lockController = false;
                    //updating the cheese counter after deleting one !!
                    cheeseLenght--;
                }
            
            
        }
    }

    private void OnApplicationQuit()
    {
        //unlocking the player controlls after quiting the game !
        playerStatesB.lockController = false;
    }
}
