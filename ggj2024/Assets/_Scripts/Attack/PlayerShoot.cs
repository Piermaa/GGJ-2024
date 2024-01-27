using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float AttackCDTimer => attackCooldownTimer;
    public float AttackCD => attackCooldown;

    [SerializeField] private int mouseButton;
    [SerializeField] private GameObject rebotinPrefab;
    [SerializeField] private float attackCooldown=.1f;

    private PlayerManager pjRef;
    private float attackCooldownTimer;
    private bool _canShootRebotin = true;
    private void Awake()
    {
        RebotinHit.OnDestroyBullet += ReloadRebotin;
        pjRef = GetComponent<PlayerManager>();
    }

    private void Update()
    {
        if(!pjRef.playerCantAttack)
        {
            if (attackCooldownTimer > 0)
            {
                attackCooldownTimer -= Time.deltaTime;
            }
            else
            {
                if (Input.GetMouseButton(mouseButton))
                {
                    if (mouseButton == 1 && _canShootRebotin)
                    {
                        _canShootRebotin = false;
                        Shoot();
                    }
                    else
                    {
                        Shoot();
                    }
                }
            }
        }
    }

    private void Shoot()
    {
        var rebotin = Instantiate(rebotinPrefab, transform.position, Quaternion.identity);
        var projectile = rebotin.GetComponent<IProjectile>();

        var dir = GetDirectionToMouse();
        projectile.Shoot(dir);

        attackCooldownTimer = attackCooldown;
    }

    public Vector3 GetDirectionToMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return (new Vector3 (mousePos.x, mousePos.y)- transform.position).normalized;
    }

    private void ReloadRebotin()
    {
        _canShootRebotin = true;
    }
}
