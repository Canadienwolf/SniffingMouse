using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    public GameObject Options;
    public GameObject MainMenu;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            BackToMainMenu();
        }
    }

    public void EnableObject(GameObject go)
    {
        go.SetActive(true);
    }

    public void DisableObject(GameObject go)
    {
        go.SetActive(false);
    }

    public void QuitGame()
    {
        PlayerPrefs.Save();
        Application.Quit();
    }
    
    public void GoToLastScene()
    {
        SceneManager.LoadScene(GameMangerScript.sceneName, LoadSceneMode.Single);
    }

    public void GoToSceneString(string idx)
    {
        SceneManager.LoadScene(idx, LoadSceneMode.Single);
    }

    public void GoToSceneInt(int idx)
    {
        SceneManager.LoadScene(idx, LoadSceneMode.Single);
    }

    public void ResumeGame(GameObject go)
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        DisableObject(go);
    }

    public void PauseGame(GameObject go)
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        EnableObject(go);
    }

    public void OptionsMenu()
    {
        MainMenu.SetActive(false);
        Options.SetActive(true);
    }

    public void BackToMainMenu()
    {
        MainMenu.SetActive(true);
        Options.SetActive(false);
    }
    
}
