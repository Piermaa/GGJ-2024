using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AjoHit : MonoBehaviour
{
    [SerializeField] private int ajoDamage;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask whatIsEnemy;
    private Camera _camera;
  
    private void Awake()
    {
        _camera = Camera.main;

        InvokeRepeating("InflictDamage",0,1);
    }
    private void LateUpdate()
    {
        transform.position = _camera.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector2(transform.position.x, transform.position.y);
    }

    private void InflictDamage()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, radius, whatIsEnemy);

        foreach (Collider2D enemy in enemies) 
        {
            enemy.GetComponent<IDamageable>().TakeDamage(ajoDamage);
        }
    }
}
