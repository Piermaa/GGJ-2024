using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour, IDamageable
{
    public Material BaseMaterial => throw new System.NotImplementedException();

    public Material FlashingWhiteMaterial => throw new System.NotImplementedException();

    public SpriteRenderer CharacterSprite => throw new System.NotImplementedException();

    [SerializeField] private SpriteRenderer _characterSprite;
    [SerializeField] private Material _flashingWhiteMaterial;
    [SerializeField] private Material _baseMaterial;

    public void Death()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
