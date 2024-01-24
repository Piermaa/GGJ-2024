using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : EnemyBehaviour
{
    [SerializeField] private Transform _playerTransform;

    private void FixedUpdate()
    {
        Vector2 dir= (_playerTransform.position - transform.position).normalized;
        transform.Translate(dir * enemyStats.MovementSpeed * Time.fixedDeltaTime);
    }

    public void SetPlayer(Transform playerTransform)
    { 
        _playerTransform = playerTransform;
    }
}
