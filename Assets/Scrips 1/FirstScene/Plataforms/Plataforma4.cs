using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma4 : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform t;
    private  Vector3 posI;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        t = GetComponent<Transform>();
        posI=new Vector3(188.24f,32.42f,61.69f);
        t.position = posI;
        rb.velocity = new Vector2(5, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        //rb.velocity = new Vector2(5, rb.velocity.y);
        if (t.position.x>posI.x)
        {
            rb.velocity = new Vector2(-3, rb.velocity.y);
        }

        if (t.position.x < 182.21f)
        {
            rb.velocity = new Vector2(5, rb.velocity.y);
        }

    }
}