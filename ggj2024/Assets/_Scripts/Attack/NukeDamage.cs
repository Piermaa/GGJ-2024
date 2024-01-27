using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukeDamage : MonoBehaviour
{
    private AudioSource nukeSound;
    private void Awake()
    {
        nukeSound.Play();
    }

    public void Hit()
    {
        EnemyManager.Instance.KillAllEnemiesOnScreen();
        Destroy(gameObject);
    }
}
