using UnityEngine;
using System;

[RequireComponent(typeof(AudioSource))]
public class BaseCharacter : MonoBehaviour, IDamageable
{
    public Material BaseMaterial => _baseMaterial;

    public Material FlashingWhiteMaterial => _flashingWhiteMaterial;

    public SpriteRenderer CharacterSprite => _characterSprite;

    public float CurrentHealth => _currentHealth;

    public AudioClip TakingDamageSound => takingDamageAudioClip;

    public Action<float> OnTakeDamage;

    [SerializeField] private SpriteRenderer _characterSprite;
    [SerializeField] private Material _flashingWhiteMaterial;
    [SerializeField] private AudioClip takingDamageAudioClip;
    [SerializeField] private DamageNotification _damageNotification;

    [SerializeField] private float resetMaterialTime;

    private AudioSource takingDamageAudioSource;

    protected float _currentHealth=100;

    private Material _baseMaterial;
    private float _resetMaterialTimer;

    protected virtual void Awake()
    {
        _baseMaterial = _characterSprite.material;
        takingDamageAudioSource = GetComponent<AudioSource>();
    }

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

    public virtual void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        _characterSprite.material= _flashingWhiteMaterial;
        _resetMaterialTimer = resetMaterialTime;
        _damageNotification.BeginDamageNotification(damage);

        OnTakeDamage?.Invoke(damage);

        takingDamageAudioSource.PlayOneShot(takingDamageAudioClip);

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
