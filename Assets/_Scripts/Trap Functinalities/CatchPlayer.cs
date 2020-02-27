using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CatchPlayer : MonoBehaviour
{
    public float endTime = 3;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.GetComponent<PickupSystem>().pickableObject == null)
            {
                Invoke("Catch", endTime);
            }
            else if(other.GetComponent<PickupSystem>().pickableObject.GetComponent<SharpOrHeavy>() == null)
            {
                Invoke("Catch", endTime);

            }
        }
    }

    void Catch()
    {
        SceneManager.LoadScene("menu_ScoreDisplay", LoadSceneMode.Single);
    }
}
