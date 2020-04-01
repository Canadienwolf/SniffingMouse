using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLockDestruction : MonoBehaviour
{
    bool destroy;
    public GameObject hitParticle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (destroy == true)
        {
            Instantiate(hitParticle, this.gameObject.transform.position, Quaternion.identity);
            //play an animation here / or use a static variable to play it in different script!
            //destroying the key!
            Destroy(this.gameObject,1);


        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lock"))
        {
            Debug.Log("its here");
            destroy = true;
            //destroying the lock!
            Destroy(collision.gameObject,1);
        }
    }
}
