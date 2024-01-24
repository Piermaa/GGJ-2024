using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectile
{
    void Shoot(Vector2 shootDirection);

    void Hit(Collider2D collision);
}
