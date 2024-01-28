using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : EnemyBehaviour
{
    [SerializeField] private Transform _playerTransform;

    private NavMeshAgent agent;

    private Rigidbody2D rb2d;
    private bool _isOnKnockbackState=false;

    protected override void Awake()
    {
        base.Awake();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = enemyStats.MovementSpeed;
        rb2d = GetComponent<Rigidbody2D>();   
        GetComponent<BaseCharacter>().OnTakeDamage+=Knockback;
    }

    private void FixedUpdate()
    {
        if (!_isOnKnockbackState)
        {
            agent.SetDestination(_playerTransform.position);
        }

        Vector2 dir = (transform.position - _playerTransform.position).normalized;
        Vector3 scale= transform.localScale;
        scale.x= dir.x < 0 ? 1:-1;
        transform.localScale = scale;
    }

    private void OnDestroy()
    {
        GetComponent<BaseCharacter>().OnTakeDamage -= Knockback;
    }

    private void Knockback(float multiplier)
    {
        StopAllCoroutines();
        StartCoroutine(ReceivingKnockBack(multiplier));
    }


    public void SetPlayer(Transform playerTransform)
    { 
        _playerTransform = playerTransform;
    }

    private IEnumerator ReceivingKnockBack(float multiplier)
    {
        Vector2 dir = (transform.position - _playerTransform.position).normalized;
        rb2d.AddForce(enemyStats.KnockbackForce * multiplier * dir, ForceMode2D.Impulse);
        _isOnKnockbackState = true;

        yield return new WaitForSeconds(enemyStats.KnockbackTime);
        _isOnKnockbackState= false;
        rb2d.velocity = Vector2.zero;
    }
 
}
