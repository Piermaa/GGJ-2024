using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] float attackDistance;

    private BaseEnemy nearEnemy;
    
    bool alreadyAttacking = false;

    private float attackCooldown;



    // Start is called before the first frame update
    void Start()
    {
        attackCooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(nearEnemy != null)
        {
            StartAttacking();
        }
    }

    private void StartAttacking()
    {
        if(attackCooldown <= 0)
        {
            attackCooldown = 1f;
            nearEnemy.TakeDamage(damage);
        }
        else
            attackCooldown -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Debug.Log("Touching Enemy");
            nearEnemy = collision.gameObject.GetComponent<BaseEnemy>();
        }
    }
}
