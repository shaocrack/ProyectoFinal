using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class daño : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //funcion para detectar la colision con el arbusto
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag =="Player")
        {
            vida.instance.dañovida();
        }
    }

}
