using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNext : MonoBehaviour
{
    public int nextSceneLoad;
    // Start is called before the first frame update
    void Start()
    {
        nextSceneLoad = FinishedLevel.nextSceneLoad;
    }

   
    public void Onclick()
    {
        //Move to next level
        SceneManager.LoadScene(nextSceneLoad);
       
    }
   
}
