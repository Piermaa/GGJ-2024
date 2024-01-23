using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class BaseEnemy : MonoBehaviour, IDamageable
{
    public Material BaseMaterial => _baseMaterial;

    public Material FlashingWhiteMaterial => _flashingWhiteMaterial;

    public SpriteRenderer CharacterSprite => _characterSprite;

    public int CurrentHealth => _currentHealth;

    public int MaxHealth => _maxHealth;

    public AudioClip TakingDamageSound => takingDamageSound;

    [SerializeField] private SpriteRenderer _characterSprite;
    [SerializeField] private Material _flashingWhiteMaterial;
    [SerializeField] private AudioClip takingDamageSound;
    [SerializeField] private float resetMaterialTime;

    [SerializeField] private int _maxHealth;
    private int _currentHealth;

    private Material _baseMaterial;
    private float _resetMaterialTimer;

    private void Awake()
    {
        _baseMaterial = _characterSprite.material;
        _currentHealth = _maxHealth;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            TakeDamage(1);
        }

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

        if (_currentHealth < 0) 
        {
            Death();
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
