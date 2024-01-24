using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Stats/EnemyStats", order = 0)]
public class EnemyStats : ScriptableObject
{
    [SerializeField] protected EnemyStatsValues _stats;
    public int MaxHealth => _stats.MaxHealth;
    public float MovementSpeed => _stats.MovementSpeed;
    public int Damage => _stats.Damage;
}

[System.Serializable]
public struct EnemyStatsValues
{
    public float MovementSpeed;
    public int MaxHealth;
    public int Damage;
}
