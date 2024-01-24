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
    private Camera mainCamera;

    [Tooltip("Cada cuantos segs spawnea 1 enemigo")]
    private void Start()
    {
        mainCamera = Camera.main;
        InvokeRepeating("SpawnEnemy", warmUpTime, spawnRate);
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
        int randomIndex = Random.Range(0, enemies.Length);
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
}
