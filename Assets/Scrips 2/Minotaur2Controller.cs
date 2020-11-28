using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur2Controller : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private SpriteRenderer spri;
    private Transform t;
    private int mov = 0;
    private int die = 0;
    private Animator anim;
    private float time_attack;
    private int attack;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        spri = GetComponent<SpriteRenderer>();
        t = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        time_attack = 0;
        attack = 0;
        // t.position = new Vector3(-10, 3, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
        time_attack = time_attack + Time.deltaTime;
        if (mov == 0)
        {
            rb.velocity = new Vector2(-5, rb.velocity.y);
        }
        if (mov == 1)
        {
            rb.velocity = new Vector2(5, rb.velocity.y);
        }

        if (time_attack>3)
        {
            anim.SetInteger("Estado",2);
            attack = 1;
            time_attack = 0;
        }else

        {
            anim.SetInteger("Estado",0);
        }
        attack = 0;
       


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
               
                rb.velocity = new Vector2(0, rb.velocity.y);
                Destroy(this.gameObject);
            }
            
        }
    }
}