using UnityEngine;

public class RebotinHit : MonoBehaviour, IProjectile
{
    [SerializeField] private float moveSpeed;
    private Vector2 _moveDirection;
    public void Shoot(Vector2 moveDir)
    {
        _moveDirection = moveDir;
    }

    private void FixedUpdate()
    {
        transform.Translate(_moveDirection * moveSpeed * Time.fixedDeltaTime);
    }
}
