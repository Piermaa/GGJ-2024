using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : EnemyBehaviour
{
    [SerializeField] private Transform _playerTransform;

    private Rigidbody2D rb2d;
    private bool _isOnKnockbackState=false;

    protected override void Awake()
    {
        base.Awake();
        rb2d = GetComponent<Rigidbody2D>();   
        GetComponent<BaseCharacter>().OnTakeDamage+=Knockback;
    }

    private void FixedUpdate()
    {
        Vector2 dir= (_playerTransform.position - transform.position).normalized;

        if (!_isOnKnockbackState)
        {
            rb2d.velocity=dir * enemyStats.MovementSpeed;
        }

        Vector3 scale= transform.localScale;
        scale.x= dir.x > 0 ? 1:-1;
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
    }
 
}
