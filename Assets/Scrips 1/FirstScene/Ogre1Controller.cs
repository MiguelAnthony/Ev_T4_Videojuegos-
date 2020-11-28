using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ogre1Controller : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private SpriteRenderer spri;
    private Transform t;
    private Animator anim;
    private int mov = 0;
    private int m = 0;
    private int die = 0;
    public GameObject knight;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        spri = GetComponent<SpriteRenderer>();
        t = GetComponent<Transform>();
        anim = GetComponent<Animator>();

        // t.position = new Vector3(-10, 3, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (knight.transform.position.x >= 38f)
        {
            m = 1;
        }

        if (m==1)
        {
            
            if (mov == 0)
            {
                
                rb.velocity = new Vector2(-5, rb.velocity.y);
            }
            if (mov == 1)
            {
                
                rb.velocity = new Vector2(5, rb.velocity.y);
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Arrow001")
        {
            spri.flipX = false;
            mov = 1;
        }
        if (other.gameObject.tag == "tree002")
        {
            mov = 0;
            spri.flipX = true;
            
        }
        if (other.gameObject.tag == "Knight")
        {
            anim.SetInteger("Estado", 1);
            die++;
            if (die == 2)
            {
                anim.SetInteger("Morir", 1);
                rb.velocity = new Vector2(0, rb.velocity.y);
                Destroy(this.gameObject);
            }
            
        }
    }
}

