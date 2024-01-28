using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D),typeof(Collider2D))]
public class EnemyDamage : EnemyBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && collision.name != "SwordSlash(Clone)")
        {
            print("PlayerInside");

            collision.GetComponent<IDamageable>().TakeDamage(enemyStats.Damage);
        }

    }
}
