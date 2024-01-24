using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Vector2 heightLimits, widthLimits;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float warmUpTime, spawnRate;

    [SerializeField] private GameObject[] enemies;

    [Tooltip("Cada cuantos segs spawnea 1 enemigo")]
    private void Start()
    {
        InvokeRepeating("SpawnEnemy", warmUpTime, spawnRate);
    }

    private void SpawnEnemy()
    {
        var enemy = Instantiate(GetRandomEnemy(), GetRandomPositionInRect(),Quaternion.identity);
        enemy.GetComponent<EnemyMovement>().SetPlayer(playerTransform);
    }

    private GameObject GetRandomEnemy()
    {
        int randomIndex = Random.Range(0, enemies.Length);
        return enemies[randomIndex];
    }

    private Vector2 GetRandomPositionInRect()
    {
        float x = Random.Range(widthLimits.x, widthLimits.y);
        float y = Random.Range(heightLimits.x, heightLimits.y);

        return new Vector2(x, y);
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
