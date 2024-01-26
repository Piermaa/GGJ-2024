using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GenericTriggerEnter : OnPlayerTriggerEnter
{
    private UnityEvent onTriggerEnterEvent;

    protected override void Trigger(GameObject playerObject)
    {
        onTriggerEnterEvent.Invoke();
    }
}
