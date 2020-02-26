using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CatchPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.GetComponent<PickupSystem>().pickableObject == null)
            {
                Invoke("Catch", 3);
            }
            else if(other.GetComponent<PickupSystem>().pickableObject.GetComponent<SharpOrHeavy>() == null)
            {
                Invoke("Catch", 3);

            }
        }
    }

    void Catch()
    {
        SceneManager.LoadScene("menu_ScoreDisplay", LoadSceneMode.Single);
    }
}
