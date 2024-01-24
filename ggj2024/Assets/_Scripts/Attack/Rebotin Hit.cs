using UnityEngine;

public class RebotinHit : MonoBehaviour, IProjectile
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector2 _moveDirection;

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
}
