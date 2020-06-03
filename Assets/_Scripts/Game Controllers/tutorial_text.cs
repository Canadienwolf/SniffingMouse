using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial_text : MonoBehaviour
{
    [TextArea]
    [SerializeField] string tut_txt;

    Text txt;

    private void Start()
    {
        txt = GameObject.Find("Tutorial_Text").GetComponent<Text>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            txt.text = tut_txt;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            txt.text = "";
        }
    }
}
