using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    float CurrentHealth { get; }
    Material BaseMaterial { get; }
    Material FlashingWhiteMaterial { get;}
    SpriteRenderer CharacterSprite { get;}
    AudioClip TakingDamageSound { get;}
    void TakeDamage(float damage);
    void Death();
}
