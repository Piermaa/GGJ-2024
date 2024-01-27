using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AjoHit : MonoBehaviour
{
    [SerializeField] private int ajoDamage;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask whatIsEnemy;
    [SerializeField] private GameObject child;
    [SerializeField] private AudioSource source;
    private Camera _camera;
    private bool unlocked=false;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        CountdownTimer.OnTimeElapsed += UnlockAjo;
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
        if (unlocked)
        {
            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, radius, whatIsEnemy);

            foreach (Collider2D enemy in enemies)
            {
                enemy.GetComponent<IDamageable>().TakeDamage(ajoDamage);
            }

            source.Play();
        }
    }

    private void UnlockAjo(int timeelapsed)
    {
        if (timeelapsed==90)
        {
            unlocked = true;
            child.SetActive(true);
        }
    }
}
