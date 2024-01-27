using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukeDamage : MonoBehaviour
{


    public void Hit()
    {
        EnemyManager.Instance.KillAllEnemiesOnScreen();
        Destroy(gameObject);
    }
}
