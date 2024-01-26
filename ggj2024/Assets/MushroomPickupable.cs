using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomPickupable : OnPlayerTriggerEnter
{
    protected override void Trigger(GameObject playerObject)
    {
        PlayerManager pj = playerObject.GetComponent<PlayerManager>();

        pj.StartCountDown = true;
        pj.MushroomPickUp = true;

        pj.ActivePickUp();  

    }
}
