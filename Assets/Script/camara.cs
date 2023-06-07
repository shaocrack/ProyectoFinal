using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{

    //para seguir al jugador
    public Transform target;
    //para los scenarios
    public Transform farBackground, middleBackground;
    private Vector2 lastPos;
    //alturas maximas y minimas en la camara
    public float minHeight, maxHeight;





    void Start()
    {
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //seguir jugador
        //transform.position = new Vector3(target.position.x,transform.position.y,transform.position.z);
        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);
        Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);
        farBackground.position = farBackground.position + new Vector3(amountToMove.x, amountToMove.y, 0f);

        middleBackground.position += new Vector3(amountToMove.x, amountToMove.y, 0f) * .5f;
        lastPos = transform.position;

    }
}