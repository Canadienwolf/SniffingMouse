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

    }
}
