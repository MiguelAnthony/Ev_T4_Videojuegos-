using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien1Controller : MonoBehaviour
{
    private int estado = 0;
    private Transform t;
    private Animator anim;
    private SpriteRenderer spri;
    private Rigidbody2D rb;
    public GameObject knitgh;
    private float time_attack;
    private int attack;
    private int die = 0;
    void Start()
    {
        t = GetComponent<Transform>();
        anim=GetComponent<Animator>();
        spri = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim.SetInteger("Estado",0);
        time_attack = 0;
        attack = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        time_attack = time_attack + Time.deltaTime;
        
        
        attack = 0;
        if(knitgh.transform.position.x+10>t.position.x)
        {
            float ti = 3 * Time.deltaTime;
            anim.SetInteger("Estado",1);
            t.position = Vector2.MoveTowards(t.position, knitgh.transform.position, ti);
            
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        
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
