using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeManager : MonoBehaviour
{
    public Image LifeBar;

    public int LifeAmount;

    public BaseCharacter PlayerRef;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRef = GameObject.FindWithTag("Player").GetComponent<BaseCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        LifeBar.fillAmount = PlayerRef.CurrentHealth / 100;
        LocateAndFollowPlayer();
        Debug.Log(LifeBar.fillAmount);
    }

    private void LocateAndFollowPlayer()
    {
        transform.position = PlayerRef.transform.position - new Vector3(0, 1f, 0);
    }
}
