using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.Playables;

public class BaseCharacter : MonoBehaviour, IDamageable
{
    public Material BaseMaterial => _baseMaterial;

    public Material FlashingWhiteMaterial => _flashingWhiteMaterial;

    public SpriteRenderer CharacterSprite => _characterSprite;

    public int CurrentHealth => _currentHealth;

    public AudioClip TakingDamageSound => takingDamageSound;

    [SerializeField] private SpriteRenderer _characterSprite;
    [SerializeField] private Material _flashingWhiteMaterial;
    [SerializeField] private AudioClip takingDamageSound;
    [SerializeField] private DamageNotification _damageNotification;

    [SerializeField] private float resetMaterialTime;

    protected int _currentHealth=100;

    private Material _baseMaterial;
    private float _resetMaterialTimer;

    protected virtual void Awake()
    {
        _baseMaterial = _characterSprite.material;
    }


    // Update is called once per frame
    void Update()
    {
        if (_resetMaterialTimer > 0)
        {
            _resetMaterialTimer -= Time.deltaTime;
            
            if (_resetMaterialTimer<=0)
            {
                _characterSprite.material = _baseMaterial;
            }
        }
    }

    public virtual void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _characterSprite.material= _flashingWhiteMaterial;
        _resetMaterialTimer = resetMaterialTime;
        _damageNotification.BeginDamageNotification(damage);

        if (_currentHealth < 0) 
        {
            Death();
        }
    }

    public virtual void Death()
    {
        Destroy(gameObject);
    }
}
