using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukePickupable : Pickupable
{
    [SerializeField] private GameObject _nukePrefab;
    protected override void Trigger(GameObject playerObject)
    {
        var nuke = Instantiate(_nukePrefab, Camera.main.transform);
        nuke.transform.localPosition = new Vector3(0,0,10);
        base.Trigger(playerObject);
    }
}
