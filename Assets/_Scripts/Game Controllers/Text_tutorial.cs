using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_tutorial : MonoBehaviour
{
    [TextArea]
    public string tutorialString;

    Text tutorialText;

    private void Start()
    {
        tutorialText = GameObject.Find("TutorialText").GetComponent<Text>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            tutorialText.text = tutorialString;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            tutorialText.text = "";
    }
}
