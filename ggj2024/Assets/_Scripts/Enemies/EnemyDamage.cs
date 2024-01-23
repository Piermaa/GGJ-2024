using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D),typeof(Collider2D))]
public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private int _damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<IDamageable>().TakeDamage(_damage);
        }  
    }
}
