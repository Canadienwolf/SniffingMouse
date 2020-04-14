using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LockDestruction : MonoBehaviour
{
    public UnityEvent openEvent;

    private void OnDestroy()
    {
        openEvent.Invoke();
    }
}
