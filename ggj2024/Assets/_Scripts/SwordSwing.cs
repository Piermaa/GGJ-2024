using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSwing : MonoBehaviour
{
    [SerializeField] private float swordDamage;

    public void Break()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            EnemyCharacter character = collision.gameObject.GetComponent<EnemyCharacter>();

            character.TakeDamage(swordDamage);
        }
    }
}
