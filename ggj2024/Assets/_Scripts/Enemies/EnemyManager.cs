using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<EnemyCharacter> EnemyList => enemiesOnScreen;

    [SerializeField] [Range(0,100)] private int nukeDropRatio;
    [SerializeField] private GameObject nukeDrop;
    [SerializeField] private DestroyActivator steamAchievement;
    public static EnemyManager Instance;
    
    private List<EnemyCharacter> enemiesOnScreen = new();
    private void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void AddEnemy(EnemyCharacter enemy)
    {
        enemiesOnScreen.Add(enemy);
    }

    public void RemoveEnemy(EnemyCharacter enemy)
    {
        enemiesOnScreen.Remove(enemy);
    }

    public void KillAllEnemiesOnScreen()
    {
        foreach (var enemy in enemiesOnScreen)
        {
            Destroy(enemy.gameObject);
        }
        enemiesOnScreen.Clear();
    }

    public void TryDropNuke(Vector2 spawnPos)
    {
        if (WillSpawnNukeDrop())
        { 
            Instantiate(nukeDrop, spawnPos, Quaternion.identity);
        }
    }

    private bool WillSpawnNukeDrop()
    {
        float chance = Random.Range(0, 100);
        
        return chance <= nukeDropRatio;
    }

    public void EnemyDeath(EnemyCharacter enemy,Vector2 deathPos)
    {
        if (steamAchievement!=null)
        {
            steamAchievement.BeginAchievements();
        }
        
        TryDropNuke(deathPos);
        RemoveEnemy(enemy);
    }
}
