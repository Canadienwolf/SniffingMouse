using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class test_visualizeTime : MonoBehaviour
{
    public test_sendScore ss;
    void Update()
    {
        GetComponent<Text>().text = ss.min + ":" + ss.seconds;
    }
}
