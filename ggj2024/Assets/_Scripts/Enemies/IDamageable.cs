using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    int CurrentHealth { get; }
    int MaxHealth { get; }
    Material BaseMaterial { get; }
    Material FlashingWhiteMaterial { get;}
    SpriteRenderer CharacterSprite { get;}
    AudioClip TakingDamageSound { get;}
    void TakeDamage(int damage);
    void Death();
}
