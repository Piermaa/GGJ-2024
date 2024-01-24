using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject rebotinPrefab;
    private bool _canShootRebotin = true;
    private void Awake()
    {
        RebotinHit.OnDestroyBullet += ReloadRebotin;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _canShootRebotin)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        _canShootRebotin=false;

        var rebotin = Instantiate(rebotinPrefab, transform.position, Quaternion.identity);
        var projectile = rebotin.GetComponent<IProjectile>();

        var dir = GetDirectionToMouse();
        projectile.Shoot(dir);
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
