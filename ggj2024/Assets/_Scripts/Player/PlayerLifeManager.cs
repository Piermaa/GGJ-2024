using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeManager : MonoBehaviour
{
    public Image LifeBar;

    public int LifeAmount;

    public BaseCharacter PlayerRef;


    private void FixedUpdate()
    {
        LocateAndFollowPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        LifeBar.fillAmount = PlayerRef.CurrentHealth / 100;
        
    }

    private void LocateAndFollowPlayer()
    {
        transform.position = PlayerRef.transform.position - new Vector3(0, .7f, 0);
    }
}
