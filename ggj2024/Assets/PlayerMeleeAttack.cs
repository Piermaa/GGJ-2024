using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] float attackDistance;
    [SerializeField] GameObject automaticAttackPivot;
    [SerializeField] EnemyList enemyListRef;

    private BaseCharacter nearEnemy;
    
    private bool alreadyAttacking = false;

    private float attackCooldown;


    // Start is called before the first frame update
    void Start()
    {
        attackCooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyListRef.enemyList.Count > 0)
        {
            AimToClosestEnemy(CloserEnemy());
        }
    }

    private BaseCharacter CloserEnemy()
    {
        float aux2distance = 0;
        float auxDistance = 10;

        BaseCharacter closerEnemy = null;

        for(int i = 0; i < enemyListRef.enemyList.Count; i++)
        {
            aux2distance = Vector2.Distance(enemyListRef.enemyList[i].transform.position, transform.position);

            if (aux2distance < auxDistance)
            {
                auxDistance = aux2distance;
                closerEnemy = enemyListRef.enemyList[i];
            }
        }

        return closerEnemy;
    }

    private void AimToClosestEnemy(BaseCharacter enemy)
    {
        nearEnemy = enemy;

        Vector3 vectorToTarget = nearEnemy.transform.position - transform.position;

        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;

        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 15);

        if (attackCooldown <= 0 && alreadyAttacking)
        {
            attackCooldown = 1f;
            Attack(nearEnemy);
        }
        else
            attackCooldown -= Time.deltaTime;
    }

    private void Attack(BaseCharacter enemy)
    {
        enemy.TakeDamage(damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            alreadyAttacking = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            enemyListRef.enemyList.Remove(collision.gameObject.GetComponent<BaseCharacter>());
            nearEnemy = null;
            alreadyAttacking = false;
        }
    }


}
