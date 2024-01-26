using UnityEngine;

public class BasicShoot : MonoBehaviour, IProjectile
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private int damage;
    [SerializeField] private float lifeTime=2;

    private Vector2 _moveDirection;

    private void FixedUpdate()
    {
        transform.Translate(_moveDirection * moveSpeed * Time.fixedDeltaTime);

        lifeTime -= Time.fixedDeltaTime;

        if (lifeTime<=0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Hit(collision);
    }

    public void Hit(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<IDamageable>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    public void Shoot(Vector2 newMoveDir)
    {
        _moveDirection = newMoveDir;
    }
}
