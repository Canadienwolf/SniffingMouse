using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharpOrHeavy : MonoBehaviour
{
    public enum Type { Sharp, Heavy}
    public Type type;
    public ParticleSystem hitSmoke;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Destructible")
        {
            switch (type)
            {
                case Type.Sharp:
                    Sharp(col.gameObject, col.contacts[0].point);
                    break;
                case Type.Heavy:
                    Heavy(col.gameObject, col.contacts[0].point);
                    break;
                default:
                    break;
            }
        }
    }

    void Sharp(GameObject go, Vector3 v3)
    {
        if (go.GetComponent<DestructibleObject>().sharp && GetComponent<Rigidbody>().velocity.magnitude >= go.GetComponent<DestructibleObject>().sharpVel)
        {
            Destroy(go);
            ParticleSystem ps = Instantiate(hitSmoke, v3, Quaternion.identity);
        }
    }

    void Heavy(GameObject go, Vector3 v3)
    {
        if (go.GetComponent<DestructibleObject>().heavy && GetComponent<Rigidbody>().velocity.magnitude >= go.GetComponent<DestructibleObject>().heavyVel)
        {
            Destroy(go);
            ParticleSystem ps = Instantiate(hitSmoke, v3, Quaternion.identity);
        }
    }
}
