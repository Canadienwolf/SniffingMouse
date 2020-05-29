using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheeseFlash : MonoBehaviour
{
    public GameObject flash;

    void OnEnable()
    {
        StartCoroutine(EnableDisable(false, 0));
        StartCoroutine(EnableDisable(true, 0.1f));
        StartCoroutine(EnableDisable(false, 0.2f));
    }

    IEnumerator EnableDisable(bool idx, float delay)
    {
        yield return new WaitForSeconds(delay);
        flash.SetActive(idx);
    }
}
