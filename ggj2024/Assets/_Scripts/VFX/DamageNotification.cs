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

    private void FixedUpdate()
    {
        Vector3 scale = transform.localScale;
        scale.x = transform.parent.localScale.x < 0 ? -1 : 1;
        transform.localScale = scale;
    }
}
