using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    Transform camTrans;
    bool rot;

    public void FinishAnim()
    {
        camTrans = GameObject.FindGameObjectWithTag("MainCamera").transform;
        GetComponent<MoveBehavior>().enabled = false;
        transform.GetChild(0).GetComponent<Animator>().SetTrigger("Win");
        rot = true;
    }

    private void Update()
    {
        if(rot)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(camTrans.eulerAngles.y + 180, Vector3.up), Time.deltaTime * 20);
    }
}
