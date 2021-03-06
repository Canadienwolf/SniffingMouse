﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelSelection : MonoBehaviour
{
    public Button[] lvlButtons;

    // Start is called before the first frame update
    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 2); /* < just for playerprefs do not change itpls !  */

        //for the lvl selections buttons!
        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 2 > levelAt)
                lvlButtons[i].interactable = false;
        }
    }
    public void UnlockLevels()
    {
        //for the lvl selections buttons!
        for (int i = 0; i < lvlButtons.Length; i++)
        {
            lvlButtons[i].interactable = true;
        }
    }

}
