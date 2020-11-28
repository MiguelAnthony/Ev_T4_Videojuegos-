using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma2Controller : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform t;
    private  Vector3 posI;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        t = GetComponent<Transform>();
        posI=new Vector3(320.08f,-2.34f,14.65f);
        t.position = posI;
        rb.velocity = new Vector2(5, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        //rb.velocity = new Vector2(5, rb.velocity.y);
        if (t.position.x>posI.x)
        {
            rb.velocity = new Vector2(-5, rb.velocity.y);
        }

        if (t.position.x < 309.5f)
        {
            rb.velocity = new Vector2(5, rb.velocity.y);
        }

    }
}
