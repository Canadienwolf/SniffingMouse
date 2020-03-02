using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_foreahc : MonoBehaviour
{
    private GameObject thisOne;
    public int length = 1;
    private int amount;

    // Start is called before the first frame update
    void Start()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 100))
        {
            amount = (int)Vector3.Distance(transform.position, hit.point);
        }

        for (int i = 0; i < amount; i++)
        {
            GameObject go = Instantiate(gameObject, transform.position + new Vector3(-1 * i, 0, 0), transform.rotation);
        }
    }
}
