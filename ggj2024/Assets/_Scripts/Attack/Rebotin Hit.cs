using UnityEngine;

public class RebotinHit : MonoBehaviour, IProjectile
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector2 _moveDirection;
    [SerializeField] private int damage;
    [SerializeField] private float lifeTime;
    private float _height;

    private void Awake()
    {
        _height = GetComponent<Collider2D>().bounds.extents.y;
    }
    public void Shoot(Vector2 moveDir)
    {
        _moveDirection = moveDir;
    }

    private void FixedUpdate()
    {
        lifeTime -= Time.deltaTime;

        if(lifeTime<0)
        {
            Destroy(gameObject);
        }


        transform.Translate(_moveDirection * moveSpeed * Time.fixedDeltaTime);

        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position); 

        if (screenPos.y >= Screen.height - 50 || screenPos.y <= 0 + 50)
        {
            _moveDirection.y *= -1;
        }

        if (screenPos.x >= Screen.width - 50 || screenPos.x <= 0 + 50)
        {
            _moveDirection.x *= -1;
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
        }
    }
}
