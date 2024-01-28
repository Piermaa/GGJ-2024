using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyActivator : MonoBehaviour
{
    public void BeginAchievements()
    {
        gameObject.SetActive(true);
    }

    public void DestroyGameObject()
    {
        Destroy(this.gameObject);
    }
}
