using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaSubController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform t;
    private  Vector3 posI;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        t = GetComponent<Transform>();
        posI=new Vector3(328.61f,22.46f,14.65f);
        t.position = posI;
        rb.velocity = new Vector2(rb.velocity.x, -5);
    }

    // Update is called once per frame
    void Update()
    {
        //rb.velocity = new Vector2(5, rb.velocity.y);
        if (t.position.y < 15.51f)
        {
            rb.velocity = new Vector2(rb.velocity.x, 5);
        }
        if (t.position.y>posI.y)
        {
            rb.velocity = new Vector2(rb.velocity.x, -5);
        }

        

    }
}
