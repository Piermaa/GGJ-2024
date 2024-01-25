using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageNotification : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private TMPro.TextMeshProUGUI _textMeshPro;
    public void BeginDamageNotification(float damage)
    { 
        _textMeshPro.text = damage.ToString();
        _animator.SetTrigger("Begin");
    }
}
