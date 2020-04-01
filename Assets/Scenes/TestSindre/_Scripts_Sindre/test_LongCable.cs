using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_LongCable : MonoBehaviour
{
    public GameObject cable;
    public GameObject plug;

    // Start is called before the first frame update
    void Start()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position + transform.forward * 2, transform.TransformDirection(Vector3.forward), out hit, 400))
        {
            GameObject spawnPlug = Instantiate(plug, hit.point, Quaternion.identity);
            spawnPlug.transform.rotation = plug.transform.rotation * Quaternion.Euler(0, 0, 180);
            cable.transform.localScale += new Vector3(0, Vector3.Distance(transform.position, hit.point), 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
