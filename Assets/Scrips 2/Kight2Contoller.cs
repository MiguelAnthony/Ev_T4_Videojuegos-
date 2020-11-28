using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Kight2Contoller : MonoBehaviour
{
    public static KnightController knightController;
    private const int ANIMATION_QUIETO=0;
        private const int ANIMATION_CAMINAR=1;
        private const int ANIMATION_SALTAR=2;
        private const int ANIMATION_CORRER=3;
        private const int ANIMATION_DESLIZAR=8;
        //private const int ANIMATION_PLANEAR=4;
        private const int ANIMATION_ATACAR=5;
        private const int ANIMATION_MORIR=1;
        private const int ANIMATION_ESCALAR=7;
        private const int ANIMATION_CUBRIRSE=15;
        private bool jump;
        private Rigidbody2D rb;
        private Transform t;
        private Animator anim;
        private SpriteRenderer spri;
      //  public GameObject kunai;
        //public GameObject leftkunai;
        public PuntajeController2 PuntajeController;
       public Text Textvidas;
        private float vidas = 100;
        private int aviso=0;
        private int saltoshechos;
        private float lifetime = 0f;
        private int ltime = 0;
        private int acct=0;
        private int vidasEn;
        public float fuerzaSalto;
        

        public int cubrirse;

        public float tiempoCubrir;
        // Start is called before the first frame update
       
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            t = GetComponent<Transform>();
            spri = GetComponent<SpriteRenderer>();
            anim = GetComponent<Animator>();
            rb.gravityScale = 10;
           // t.position = new Vector3(-15, -8, 0);
            aviso = 0;
            Textvidas.text = "Vidas: "+vidas;
            lifetime = 0;
            saltoshechos = 0;
            cubrirse = 0;
            tiempoCubrir = 0;
        }
    
        // Update is called once per frame
        void Update()
        {
            
            lifetime = lifetime + Time.deltaTime;
            tiempoCubrir = tiempoCubrir + Time.deltaTime;
            //Debug.Log(lifetime);
            acct = 0;
            rb.velocity = new Vector2(0, rb.velocity.y);
            rb.gravityScale = 10;
            anim.SetInteger("Estado", ANIMATION_QUIETO);

            if (vidas < 100 && lifetime > 4)
            {
                lifetime = 0;
                ltime = 1;
            }

            if (ltime == 1)
            {
                vidas = vidas + 2;
                Textvidas.text = "Vidas: " + vidas;
                ltime = 0;
            }

            if (Input.GetKey(KeyCode.LeftControl))
            {
                rb.velocity = new Vector2(8, rb.velocity.y);
                anim.SetInteger("Estado", ANIMATION_DESLIZAR);
                spri.flipX = false;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.velocity = new Vector2(8, rb.velocity.y);
                anim.SetInteger("Estado", ANIMATION_CAMINAR);
                spri.flipX = false;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.velocity = new Vector2(-8, rb.velocity.y);
                anim.SetInteger("Estado", ANIMATION_CAMINAR);
                spri.flipX = true;
            }

            if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftShift))
            {
                rb.velocity = new Vector2(10, rb.velocity.y);
                anim.SetInteger("Estado", ANIMATION_CORRER);
                spri.flipX = false;
            }
            if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.LeftShift))
            {
                rb.velocity = new Vector2(-10, rb.velocity.y);
                spri.flipX=true;
                anim.SetInteger("Estado", ANIMATION_CORRER);
                
            }

            if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftControl))
            {
                rb.velocity = new Vector2(10, rb.velocity.y);
                anim.SetInteger("Estado", ANIMATION_DESLIZAR);
                spri.flipX = false;
            }
            if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.LeftControl))
            {
                rb.velocity = new Vector2(-10, rb.velocity.y);
                spri.flipX=true;
                anim.SetInteger("Estado", ANIMATION_DESLIZAR);
                
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (saltoshechos < 2)
                {
                    anim.SetInteger("Estado", ANIMATION_SALTAR);
                    rb.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse);
                    saltoshechos++;

                }
            }
            if (Input.GetKey(KeyCode.D)&&tiempoCubrir>5)
            {
                //tiempoCubrir = tiempoCubrir + Time.deltaTime;
                if (tiempoCubrir < 8)
                {
                    cubrirse = 1;
                    anim.SetInteger("Estado", ANIMATION_CUBRIRSE);
                    
                }
                
                if (tiempoCubrir >= 8)
                {
                    cubrirse = 0;
                    anim.SetInteger("Estado", ANIMATION_QUIETO);
                    tiempoCubrir = 0;
                    
                }

                
            }
            
            
            

            if (Input.GetKey(KeyCode.A))
            {
                if (spri.flipX)
                {
                    var kunaiposition = new Vector3(t.position.x - 2f, t.position.y, t.position.z);
                    //Instantiate(leftkunai,kunaiposition,Quaternion.identity);
                }
                else
                {
                    var kunaiposition2 = new Vector3(t.position.x + 2f, t.position.y, t.position.z);
                    // Instantiate(kunai,kunaiposition2,Quaternion.identity);
                }

                anim.SetInteger("Estado", ANIMATION_ATACAR);
                acct = 1;
            }

            

            if (t.position.y > 4)
            {

                // Debug.Log("aviso activado");
                aviso = 1;
            }

            if (t.position.y < -7)
            {
                if (aviso == 1)
                {
                   // anim.SetInteger("Morir", ANIMATION_MORIR);
                }

            }

            if (vidas <= 0)
            {
                restartGame();
            }

           
            

        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
          
            if (other.gameObject.tag== "ground"||other.gameObject.tag=="Caja")
                saltoshechos = 0;
            
            //Caballero pierde vida con colision
            if (other.gameObject.tag == "minotauro"&&acct==0)
            {
                if (cubrirse == 0)
                {
                    PuntajeController.AddPoints(15);
                    vidas=vidas-10;
                    Destroy(other.gameObject);
                    Debug.Log("Vidas"+vidas);
                    Textvidas.text = "Vidas: "+vidas;
                    lifetime = 0;
                }
                else
                {
                    PuntajeController.AddPoints(15);
                    lifetime = 0;
                }
            }
            if (other.gameObject.tag == "minotauro2"&&acct==0)
            {
                if (cubrirse == 0)
                {
                    PuntajeController.AddPoints(25);
                    vidas=vidas-15;
                    Destroy(other.gameObject);
                    Debug.Log("Vidas"+vidas);
                    Textvidas.text = "Vidas: "+vidas;
                    lifetime = 0;
                }
                else
                {
                    PuntajeController.AddPoints(25);
                    lifetime = 0;
                }
                
            }
            if (other.gameObject.tag == "minotauro3"&&acct==0)
            {
                if (cubrirse == 0)
                {
                    PuntajeController.AddPoints(50);
                    vidas=vidas-20;
                    Destroy(other.gameObject);
                    Debug.Log("Vidas"+vidas);
                    Textvidas.text = "Vidas: "+vidas;
                    lifetime = 0;
                }
                else
                {
                    PuntajeController.AddPoints(50);
                    lifetime = 0;
                }
                
               
            }
            
            //Caballero Suma puntos por ataque
            if (other.gameObject.tag == "minotauro"&&acct==1)
            {
                PuntajeController.AddPoints(15);
               // Destroy(other.gameObject);
            }
            if (other.gameObject.tag == "minotauro2"&&acct==1)
            {
                PuntajeController.AddPoints(25);
               // Destroy(other.gameObject);
            }
            if (other.gameObject.tag == "minotauro3"&&acct==1)
            {
                PuntajeController.AddPoints(50);
                // Destroy(other.gameObject);
            } 

            if (vidas < 0)
            {
                
              
                anim.SetInteger("Morir", ANIMATION_MORIR);
                

            }
        }

        

        private void OnTriggerStay2D(Collider2D other) {
           
           
            rb.velocity = new Vector2(rb.velocity.x, 0);
            if (other.gameObject.tag == "water")
            {
                
                
                restartGame();
            }
            if(other.gameObject.tag == "escalera"){
                // Debug.Log("Esta chocando");
           
                rb.gravityScale = 0;
                rb.velocity = new Vector2(rb.velocity.x, 0);
                //anim.SetInteger("Escalar", ANIMATION_ESCALAR);
                if(Input.GetKey(KeyCode.UpArrow)){
                    rb.velocity = new Vector2(rb.velocity.x, 8); 
                
                }
                if(Input.GetKey(KeyCode.DownArrow)){
                    rb.velocity = new Vector2(rb.velocity.x, -8); 
                 
                }
            }
           
        }

        public void restartGame()
        {
            SceneManager.LoadScene("SampleScene");
        }
}



      