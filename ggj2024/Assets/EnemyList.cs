using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyList : MonoBehaviour
{
    public List<BaseCharacter> enemyList;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            enemyList.Add(collision.gameObject.GetComponent<BaseCharacter>());
        }
    }
}
