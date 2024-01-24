using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : BaseCharacter
{
    public EnemyStats Stats =>stats;

    [SerializeField] private EnemyStats stats;

    protected override void Awake()
    {
        base.Awake();
        _currentHealth = stats.MaxHealth;
    }

    public override void Death()
    {
        EnemyManager.Instance.EnemyDeath(this, transform.position);
        base.Death();
    }

}
