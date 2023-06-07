using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoCOntroller : MonoBehaviour
{
    //velocidad del enemigo
    public float moveSpeed;
    //de donde a donde se movera
    public Transform leftPoint, rightnPoint;

    private bool movinRight;
    private Rigidbody2D theRB;
    //para girarlo
    public SpriteRenderer theSR;
    public float moveTime, WaitTime;
    private float moveCount, WaitCount;

    
    void Start()
    {
        theRB=GetComponent<Rigidbody2D>();
        leftPoint.parent = null;
        rightnPoint.parent = null;
        movinRight = true;
        moveCount = moveTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveCount >0)
        {
            moveCount -=Time.deltaTime;
            if (movinRight)
            {
                theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);

                theSR.flipX = true;

                if (transform.position.x > rightnPoint.position.x)
                {
                    movinRight = false;
                }
            }
            else
            {
                theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);

                theSR.flipX = false;
                if (transform.position.x < leftPoint.position.x)
                {
                    movinRight = true;
                }

            }
            if (moveCount <=0)
            {
                WaitCount = Random.Range(WaitTime *.75f,WaitTime *1.25f);
            }
        }else if (WaitCount >0) 
        { 
        WaitCount -= Time.deltaTime;
        theRB.velocity =new Vector2(0f,theRB.velocity.y);
            if (WaitCount <= 0)
            {
                moveCount = Random.Range(moveTime * .75f, WaitTime * 1.25f);
            }

        }
        
        
    }
}
