using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BasicShoot : MonoBehaviour, IProjectile
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private int damage;
    [SerializeField] private float lifeTime=2;
    [SerializeField] private AudioClip shootSound;

    private Vector2 _moveDirection;

    private void Awake()
    {
        AudioSource source =GetComponent<AudioSource>();
        source.pitch = UnityEngine.Random.Range(0.9f, 1.2f);
        source.PlayOneShot(shootSound);
    }

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
