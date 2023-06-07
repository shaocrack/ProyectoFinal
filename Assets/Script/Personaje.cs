using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    public  static Personaje instance;
    [Header("Movimiento")]
    public float moveSpeed;
    [Header("Salto")]
    public float jumpForce;
    private bool saltoalto;// (candoublejump)

    [Header("Componentes")]
    public Rigidbody2D thRB;

    [Header("animator")]
    public Animator anim;
    //para los giros en los movimientos
    private SpriteRenderer theSr;

    [Header("Grounded")]
    private bool isGrounded;
    public Transform groundCheckpoint;
    public LayerMask whatIsGround;

    //para recuperars
    public float KnockBackLenght,KnockBackForce;
    private float KnockCounter;

    private void Awake()
    {
        
        instance = this;
    }
    private void Start()
    {
        //para asignar a nuestro personaje las animaciones (y poder utilizarlos en privado)
        anim=GetComponent<Animator>();
        theSr=GetComponent<SpriteRenderer>();

    }

    private void Update()
    {
        if (KnockCounter <=0)
        {
            //movimiento en x
            thRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), thRB.velocity.y);
            //para detectar el piso
            isGrounded = Physics2D.OverlapCircle(groundCheckpoint.position, .2f, whatIsGround);
            if (Input.GetButtonDown("Jump"))
            {
                //pra decir que solo salte cuando esta en el piso
                if (isGrounded)
                {
                    saltoalto = true;

                }
                if (isGrounded)
                {
                    thRB.velocity = new Vector2(thRB.velocity.x, jumpForce);

                }
                else
                {
                    if (saltoalto)
                    {
                        thRB.velocity = new Vector2(thRB.velocity.x, jumpForce);
                        saltoalto = false;
                    }
                }


            }
            //para el giro
            if (thRB.velocity.x < 0)
            {
                theSr.flipX = true;
            }
            else if (thRB.velocity.x > 0)
            {
                theSr.flipX = false;
            }

        }
        else 
        {

            KnockCounter -= Time.deltaTime;
        
        }
        
     

        //para activar las animaciones al movernos 
        anim.SetFloat("moveSpeed",Mathf.Abs(thRB.velocity.x));
        anim.SetBool("isGrounded", isGrounded);

    }

    public void Knockback() 
    {
        KnockCounter = KnockBackLenght;
        thRB.velocity = new Vector2(0f, KnockBackForce);
    
    }

    

}

