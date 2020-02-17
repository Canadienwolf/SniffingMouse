using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharpOrHeavy : MonoBehaviour
{
    public enum Type { Sharp, Heavy}
    public Type type;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Destructible")
        {
            switch (type)
            {
                case Type.Sharp:
                    Sharp(col.gameObject);
                    break;
                case Type.Heavy:
                    Heavy(col.gameObject);
                    break;
                default:
                    break;
            }
        }
    }

    void Sharp(GameObject go)
    {
        if (go.GetComponent<DestructibleObject>().sharp && GetComponent<Rigidbody>().velocity.magnitude >= go.GetComponent<DestructibleObject>().sharpVel)
        {
            Destroy(go);
        }
    }

    void Heavy(GameObject go)
    {
        if (go.GetComponent<DestructibleObject>().heavy && GetComponent<Rigidbody>().velocity.magnitude >= go.GetComponent<DestructibleObject>().heavyVel)
        {
            Destroy(go);
        }
    }
}
