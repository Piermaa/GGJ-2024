using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : BaseCharacter
{
    public EnemyStats Stats =>stats;
    public int Damage => damage;

    [SerializeField] private EnemyStats stats;
    [SerializeField] private int damage;


    protected override void Awake()
    {
        base.Awake();
        _currentHealth = stats.MaxHealth;
    }

    public override void Death()
    {
        base .Death();
        GetComponent<Animator>().SetTrigger("Death");
        
        isDead = true;
        EnemyManager.Instance.EnemyDeath(this, transform.position);
    }

    public void DeathFinish()
    {
        Destroy(gameObject);
    }

}
