using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukePickupable : Pickupable
{
    [SerializeField] private GameObject _nukePrefab;
    protected override void Trigger(GameObject playerObject)
    {
        Instantiate(_nukePrefab);
        base.Trigger(playerObject);
    }
}
