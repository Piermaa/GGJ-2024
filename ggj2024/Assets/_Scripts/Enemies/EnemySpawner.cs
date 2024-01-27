using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Vector2 heightLimits, widthLimits;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private int enemiesPerSpawn;
    [SerializeField] private float warmUpTime, spawnRate;
    [SerializeField] private float enemyHalfHeight=50;

    public bool pacmanMode = false;
    private float spawnTimer;
    private Camera mainCamera;
    private int difficulty=1;

    [Tooltip("Cada cuantos segs spawnea 1 enemigo")]
    private void Start()
    {
        spawnTimer = spawnRate + warmUpTime;
        mainCamera = Camera.main;
        CountdownTimer.OnTimeElapsed += TimeElapsed;
    }

    private void Update()
    {
        if (spawnTimer>0)
        {
            spawnTimer -= Time.deltaTime;
        }
        else
        {
            spawnTimer = spawnRate;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        for (int i = 0; i < enemiesPerSpawn; i++)
        {
            var enemy = Instantiate(GetRandomEnemy(), GetEnemySpawnPos(), Quaternion.identity);
            enemy.GetComponent<EnemyMovement>().SetPlayer(playerTransform);
        }
    }

    private Vector2 GetEnemySpawnPos()
    {
        Vector2 spawnPos = Vector2.zero;
        do
        {
            spawnPos = GetRandomPositionInRect();
        }
        while (IsSpawnPosInLimits(spawnPos));

        return spawnPos;
    }

    private Vector2 GetRandomPositionInRect()
    {
        float x = Random.Range(widthLimits.x, widthLimits.y);
        float y = Random.Range(heightLimits.x, heightLimits.y);

        return new Vector2(x, y);
    }

    /// <summary>
    /// Retorna true cuando esta adentro del frustrum de la camara
    /// </summary>
    /// <param name="spawnpos"></param>
    /// <returns></returns>
    private bool IsSpawnPosInLimits(Vector2 spawnpos)
    {
        Vector2 spawnPosInCamera = mainCamera.WorldToScreenPoint(spawnpos);

        return // osea si esta adentro de la pantalla
           (spawnPosInCamera.x < Screen.width + enemyHalfHeight &&
            spawnPosInCamera.x > -enemyHalfHeight &&
            spawnPosInCamera.y < Screen.height + enemyHalfHeight &&
            spawnPosInCamera.y > -enemyHalfHeight);
    }

    private GameObject GetRandomEnemy()
    {
        if (pacmanMode)
        {
            return enemies[3];
        }

        int randomIndex = Random.Range(0, (difficulty/3));
        return enemies[randomIndex];
    }

  

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(new Vector2( widthLimits.x, heightLimits.x),1);
        Gizmos.DrawSphere(new Vector2( widthLimits.y, heightLimits.x),1);
        Gizmos.DrawSphere(new Vector2( widthLimits.x, heightLimits.y),1);
        Gizmos.DrawSphere(new Vector2( widthLimits.y, heightLimits.y),1);

        Gizmos.DrawLine(new Vector2(widthLimits.x, heightLimits.x), new Vector2(widthLimits.y, heightLimits.x));
        Gizmos.DrawLine(new Vector2(widthLimits.x, heightLimits.y), new Vector2(widthLimits.y, heightLimits.y));
        Gizmos.DrawLine(new Vector2(widthLimits.x, heightLimits.x), new Vector2(widthLimits.x, heightLimits.y));
        Gizmos.DrawLine(new Vector2(widthLimits.y, heightLimits.x), new Vector2(widthLimits.y, heightLimits.y));
    }

    private void TimeElapsed(int currentTime)
    {
        difficulty++;
        spawnRate-=.4f;
        enemiesPerSpawn++;
    }

    public void SpawnBurst(EnemyCharacter newEnemy, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            var enemy = Instantiate(newEnemy, GetEnemySpawnPos(), Quaternion.identity);
            enemy.GetComponent<EnemyMovement>().SetPlayer(playerTransform);
        }
    }
}
