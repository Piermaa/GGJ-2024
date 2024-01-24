using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : OnPlayerTriggerEnter
{
    protected override void Trigger(GameObject playerObject)
    {
        Destroy(gameObject);
    }
}
