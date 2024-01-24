using System.Collections;
using System;
using UnityEngine;

public interface IProjectile
{
    void Shoot(Vector2 shootDirection);

    void Hit(Collider2D collision);

}
