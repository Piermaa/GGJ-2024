using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    private float hor;
    private float ver;

    private Rigidbody2D rb;

    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        
        rb.velocity = new Vector2 (hor, ver) * speed;

        if (hor < 0)
            transform.rotation = Quaternion.Euler(new Vector3 (0, 180, 0));
        else if(hor > 0)
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

        if (hor != 0 || ver != 0)
            anim.SetBool("Walk", true);
        else
            anim.SetBool("Walk", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
