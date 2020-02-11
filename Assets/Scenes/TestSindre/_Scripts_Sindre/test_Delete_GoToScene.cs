using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class test_Delete_GoToScene : MonoBehaviour
{
    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Cursor.visible = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }

    public void GoToScene(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum, LoadSceneMode.Single);
    }
}
