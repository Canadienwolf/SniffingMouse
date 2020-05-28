using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountingCheese : MonoBehaviour
{
    private int  cheeseNbrEnd;
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        cheeseNbrEnd = GameObject.FindGameObjectsWithTag("Cheese").Length;
    }
    private void OnDestroy()
    {
        PlayerPrefs.SetInt("Level"+SceneManager.GetActiveScene().buildIndex+"cheese",cheeseNbrEnd);
    }
}
