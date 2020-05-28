using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FeedbackCheeseUi : MonoBehaviour
{
    public GameObject[] cheeseLevel1, cheeseLevel2, cheeseLevel3, cheeseLevel4, cheeseLevel5;
    public GameObject[] cheeseLevel6, cheeseLevel7, cheeseLevel8, cheeseLevel9, cheeseLevel10;
    int level1cheeseLenght, level2cheeseLenght, level3cheeseLenght, level4cheeseLenght, level5cheeseLenght;
    int level10cheeseLenght, level9cheeseLenght, level8cheeseLenght, level7cheeseLenght, level6cheeseLenght;
    public Sprite newCheeseUi;
    // Start is called before the first frame update
    void Start()
    {
        SetinCheeseCnt();
        ChangingCheeseUi();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetinCheeseCnt()
    {
        level1cheeseLenght = cheeseLevel1.Length - PlayerPrefs.GetInt("Level2cheese");
        level2cheeseLenght = cheeseLevel2.Length - PlayerPrefs.GetInt("Level3cheese");
        level3cheeseLenght = cheeseLevel3.Length - PlayerPrefs.GetInt("Level4cheese");
        level4cheeseLenght = cheeseLevel4.Length - PlayerPrefs.GetInt("Level5cheese");
        level5cheeseLenght = cheeseLevel5.Length - PlayerPrefs.GetInt("Level6cheese");
        level6cheeseLenght = cheeseLevel6.Length - PlayerPrefs.GetInt("Level7cheese");
        level7cheeseLenght = cheeseLevel7.Length - PlayerPrefs.GetInt("Level8cheese");
        level8cheeseLenght = cheeseLevel8.Length - PlayerPrefs.GetInt("Level9cheese");
        level9cheeseLenght = cheeseLevel9.Length - PlayerPrefs.GetInt("Level10cheese");
        level10cheeseLenght = cheeseLevel10.Length - PlayerPrefs.GetInt("Level11cheese");
    }
    void ChangingCheeseUi()
    {
        for (int i = 0; i < level1cheeseLenght; i++)//level1
        {
            cheeseLevel1[i].GetComponent<Image>().sprite = newCheeseUi;
        }
        for (int i = 0; i < level2cheeseLenght; i++)//level1
        {
            cheeseLevel2[i].GetComponent<Image>().sprite = newCheeseUi;
        }
        for (int i = 0; i < level3cheeseLenght; i++)//level1
        {
            cheeseLevel3[i].GetComponent<Image>().sprite = newCheeseUi;
        }
        for (int i = 0; i < level4cheeseLenght; i++)//level1
        {
            cheeseLevel4[i].GetComponent<Image>().sprite = newCheeseUi;
        }
        for (int i = 0; i < level5cheeseLenght; i++)//level1
        {
            cheeseLevel5[i].GetComponent<Image>().sprite = newCheeseUi;
        }
        for (int i = 0; i < level6cheeseLenght; i++)//level1
        {
            cheeseLevel6[i].GetComponent<Image>().sprite = newCheeseUi;
        }
        for (int i = 0; i < level7cheeseLenght; i++)//level1
        {
            cheeseLevel7[i].GetComponent<Image>().sprite = newCheeseUi;
        }
        for (int i = 0; i < level8cheeseLenght; i++)//level1
        {
            cheeseLevel8[i].GetComponent<Image>().sprite = newCheeseUi;
        }
        for (int i = 0; i < level9cheeseLenght; i++)//level1
        {
            cheeseLevel9[i].GetComponent<Image>().sprite = newCheeseUi;
        }
        for (int i = 0; i < level10cheeseLenght; i++)//level1
        {
            cheeseLevel10[i].GetComponent<Image>().sprite = newCheeseUi;
        }
    }
}
