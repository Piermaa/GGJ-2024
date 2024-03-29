using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    protected EnemyStats enemyStats;
    protected virtual void Awake()
    {
        enemyStats = GetComponent<EnemyCharacter>().Stats;
    }
}
