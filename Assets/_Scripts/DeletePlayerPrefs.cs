using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeletePlayerPrefs : MonoBehaviour
{
    
    // Update is called once per frame
  /*  void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            PlayerPrefs.DeleteAll();
        }
    }*/
    public void ResetLevels()
    {
        //PlayerPrefs.DeleteAll();
        PlayerPrefs.DeleteKey("levelAt");
        SceneManager.LoadScene("menu_levelSelection");
        //reset the cheese uis
        for (int i = 2; i <= 3; i++)
        {
            PlayerPrefs.SetInt("Level" + i + "cheese", 5);
        }
        for (int i = 5; i <= 6; i++)
        {
            PlayerPrefs.SetInt("Level" + i + "cheese", 6);
        }
        for (int i=9;i<=11;i++)
        {
            PlayerPrefs.SetInt("Level"+i+"cheese",6);
        }
        PlayerPrefs.SetInt("Level4cheese", 7);
        PlayerPrefs.SetInt("Level7cheese", 4);
        PlayerPrefs.SetInt("Level8cheese", 7);


    }
}
