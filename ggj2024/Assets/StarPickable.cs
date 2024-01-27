using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPickable : OnPlayerTriggerEnter
{
    protected override void Trigger(GameObject playerObject)
    {
        PlayerManager pj = playerObject.GetComponent<PlayerManager>();

        pj.StartCountDown = true;
        pj.StarPickUp = true;

        pj.ActivePickUp();

        Destroy(gameObject);
    }
}
