using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] float attackDistance;
    [SerializeField] float enemyDistance;

    private BaseCharacter nearEnemy;
    
    private bool alreadyAttacking = false;

    private float attackCooldown;

    private List<GameObject> enemyList;


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
            StartAttacking(CloserEnemy());
        }
    }

    private GameObject CloserEnemy()
    {
        float aux2distance = 0;
        float auxDistance = 0;

        GameObject closerEnemy = null;

        for(int i = 0; i < enemyList.Count; i++)
        {
            aux2distance = Vector2.Distance(enemyList[i].transform.position, transform.position);

            if (aux2distance < enemyDistance && aux2distance < auxDistance)
            {
                auxDistance = aux2distance;
                closerEnemy = enemyList[i];
            }
        }

        return closerEnemy;
    }

    private void StartAttacking(GameObject enemy)
    {
        nearEnemy = enemy.GetComponent<BaseCharacter>();

        if (attackCooldown <= 0)
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
            enemyList.Add(collision.gameObject.GetComponent<GameObject>());
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, enemyDistance);
        for (int i = 0; i < enemyList.Count; i++)
        {
            Gizmos.DrawLine(enemyList[i].transform.position, transform.position);
        }
        
    }
}
