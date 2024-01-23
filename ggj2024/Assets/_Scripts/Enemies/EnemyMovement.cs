using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private Transform _playerTransform;


    private void FixedUpdate()
    {
        Vector2 dir= _playerTransform.position - transform.position;
        transform.Translate(dir * _movementSpeed * Time.fixedDeltaTime);
    }
}
