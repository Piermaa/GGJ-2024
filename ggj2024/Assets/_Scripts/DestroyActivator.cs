using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyActivator : MonoBehaviour
{
    public void DestroyGameObject()
    {
        Destroy(this.gameObject);
    }
}
