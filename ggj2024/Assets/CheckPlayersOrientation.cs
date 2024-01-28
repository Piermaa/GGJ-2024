using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayersOrientation : MonoBehaviour
{
    private Transform pjOrientation;

    // Start is called before the first frame update
    void Start()
    {
        pjOrientation = GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pjOrientation.transform.localScale.x < 0)
            transform.right = new Vector3(-1, 1, 1);
    }
}
