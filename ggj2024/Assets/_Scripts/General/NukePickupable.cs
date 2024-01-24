using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukePickupable : Pickupable
{
    [SerializeField] private GameObject _nukePrefab;
    protected override void Trigger(GameObject playerObject)
    {
        var nuke = Instantiate(_nukePrefab, playerObject.transform);
        nuke.transform.localPosition = Vector3.zero;
        base.Trigger(playerObject);
    }
}
