using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerTriggerEnter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Trigger(collision.gameObject);
        }
    }

    protected virtual void Trigger(GameObject playerObject)
    {
        
    }
}
