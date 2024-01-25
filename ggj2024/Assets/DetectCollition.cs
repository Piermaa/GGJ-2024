using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollition : MonoBehaviour
{
    public BaseCharacter PlayerRef;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRef = GameObject.FindWithTag("Player").GetComponent<BaseCharacter>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            PlayerRef.TakeDamage(collision.gameObject.GetComponent<EnemyCharacter>().Damage);
        }
    }
}
