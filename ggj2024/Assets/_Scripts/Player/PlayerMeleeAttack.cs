using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] float attackDistance;
    [SerializeField] private GameObject swordSwing;
    [SerializeField] private AudioClip slashClip;

    private AudioSource source;
    private EnemyCharacter nearEnemy;
    private bool alreadyAttacking = false;
    private float attackCooldown;
    private Animator anim;
    private PlayerManager pjRef;


    private float angle;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        pjRef = GetComponentInParent<PlayerManager>();
        attackCooldown = 0;
        anim = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyManager.Instance.EnemyList.Count > 0 && !pjRef.playerCantAttack)
        {
            AimToClosestEnemy(CloserEnemy());
        }
    }

    private EnemyCharacter CloserEnemy()
    {
        float aux2distance = 0;
        float auxDistance = 1000;

        EnemyCharacter closerEnemy = null;

        for(int i = 0; i < EnemyManager.Instance.EnemyList.Count; i++)
        {
            aux2distance = Vector2.Distance(EnemyManager.Instance.EnemyList[i].transform.position, transform.position);

            if (aux2distance < auxDistance)
            {
                auxDistance = aux2distance;
                closerEnemy = EnemyManager.Instance.EnemyList[i];
            }
       
        }

        return closerEnemy;
    }

    private void AimToClosestEnemy(EnemyCharacter enemy)
    {
        nearEnemy = enemy;

        Vector3 vectorToTarget = nearEnemy.transform.position - transform.position;

        angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;

        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 15);

        if (attackCooldown <= 0 && alreadyAttacking)
        {
            if(vectorToTarget.x < 0)
                anim.SetTrigger("AttackBehind");
            else
                anim.SetTrigger("Attack");

            attackCooldown = 1f;
        }
        else
            attackCooldown -= Time.deltaTime;
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
            nearEnemy = null;
            alreadyAttacking = false;
        }
    }

    public void ShowAttack()
    {
        source.PlayOneShot(slashClip);
        Instantiate(swordSwing, nearEnemy.transform.position, Quaternion.Euler(Vector3.forward * angle + new Vector3(0, 0, 77)));
    }
    
}
