using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_expandAndDestroy : MonoBehaviour
{
    public float destroyTime = 5f;
    public float expandSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(1, 1, 1) * expandSpeed * Time.deltaTime;
    }
}
