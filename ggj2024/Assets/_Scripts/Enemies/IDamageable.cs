using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    Material BaseMaterial { get; }
    Material FlashingWhiteMaterial { get;}
    SpriteRenderer CharacterSprite { get;}
    void TakeDamage();
    void Death();

}
