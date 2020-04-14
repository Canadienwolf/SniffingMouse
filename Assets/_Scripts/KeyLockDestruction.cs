using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyLockDestruction : MonoBehaviour
{
    public GameObject hitParticle;
    public UnityEvent open;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lock"))
        {
            //destroying the lock!
            Destroy(collision.gameObject, 1);
            //Calls a method from another script
            open.Invoke();
            Instantiate(hitParticle, this.gameObject.transform.position, Quaternion.identity);
            //destroying the key!
            Destroy(this.gameObject);
        }
    }
}
