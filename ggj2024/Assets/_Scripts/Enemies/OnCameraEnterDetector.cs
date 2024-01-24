using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCameraEnterDetector : MonoBehaviour
{
    private EnemyCharacter enemyCharacter;

    private void Awake()
    {
        enemyCharacter = GetComponentInParent<EnemyCharacter>();
    }

    private void OnBecameVisible()
    {
        print("Visible!!");
        EnemyManager.Instance.AddEnemy(enemyCharacter);
    }

    private void OnBecameInvisible()
    {
        EnemyManager.Instance.RemoveEnemy(enemyCharacter);
    }
}
