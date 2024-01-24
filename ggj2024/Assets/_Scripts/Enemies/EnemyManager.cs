using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            print(enemiesOnScreen.Count);
            KillAllEnemiesOnScreen();
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
}
