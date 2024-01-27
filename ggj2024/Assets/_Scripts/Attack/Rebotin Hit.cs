using UnityEngine;
using System;

[RequireComponent(typeof(AudioSource))]
public class RebotinHit : MonoBehaviour, IProjectile
{
    public Action OnBounce;

    public static event Action OnDestroyBullet;

    [SerializeField] private float moveSpeed;
    [SerializeField] private int damage;
    [SerializeField] private int maxBounces;
    [SerializeField] private Vector2 _moveDirection;
    [SerializeField] private AudioClip shootSound;
    [SerializeField] private AudioClip reboteSound;

    private int _bouncesCounter;

    private void Awake()
    {
        GetComponent<AudioSource>().PlayOneShot(shootSound);
        OnBounce += Bounce;
    }

    private void FixedUpdate()
    {
        transform.Translate(_moveDirection * moveSpeed * Time.fixedDeltaTime);

        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position); 

        if (screenPos.y >= Screen.height - 50 || screenPos.y <= 0 + 50)
        {
            _moveDirection.y *= -1;
            OnBounce?.Invoke();

            transform.position += new Vector3(0, .5f * _moveDirection.y, 0);
        }

        if (screenPos.x >= Screen.width - 50 || screenPos.x <= 0 + 50)
        {
            _moveDirection.x *= -1;
            OnBounce?.Invoke();

            transform.position += new Vector3(.5f * _moveDirection.x, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Hit(collision);
    }

    private void OnDestroy()
    {
        OnBounce -= Bounce;
        OnDestroyBullet.Invoke();
    }

    public void Shoot(Vector2 newMoveDir)
    {
        _moveDirection = newMoveDir;
    }

    public void Hit(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<IDamageable>().TakeDamage(damage);
        }
    }

    private void Bounce()
    {
        _bouncesCounter++;
        GetComponent<AudioSource>().PlayOneShot(reboteSound);
        if (_bouncesCounter==maxBounces)
        {
            Destroy(gameObject);
        }
    }
}
