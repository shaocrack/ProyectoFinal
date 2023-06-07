using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vida : MonoBehaviour
{
    //para poderlo utilzar en otros lados usamos
    public static vida instance;
    //para el conteo de vida
    public int fullvida, lowvida;
    //tiempo para poder sobrevivir despues de un daños
    //invisiblelengtgh,invisiblecounter
    public float sobrevivir,tiempoSobrevivir;
    //lowvida(currentvida)
    //accion de reaccion
    private SpriteRenderer theSR;
    public GameObject deathEffect;

    //usamos la funcion awake para el uso de la instancia
    private void Awake()
    {
            instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        lowvida = fullvida; 
        theSR=GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (tiempoSobrevivir >0)
        {
            tiempoSobrevivir -= Time.deltaTime;
            //cambiar de color al golpe
            if (tiempoSobrevivir <0)
            {

                theSR.color = new Color(theSR.color.r,theSR.color.g,theSR.color.b,1f);
            }
        }
    }
    //funcion para el daño
    public void dañovida() 
    {

        //agregamos condiciones en el tiempo de reaccion para no perder vidas rapidamente
        if (tiempoSobrevivir <=0)
        {
            lowvida--;
            Personaje.instance.anim.SetTrigger("Hurt");
            if (lowvida <= 0)
            {
                lowvida = 0;
                Instantiate(deathEffect, Personaje.instance.transform.position, Personaje.instance.transform.rotation);
                //gameObject.SetActive(false);
                LevelManager.instance.RespawnPlayer();
            }
            else 
            {
                tiempoSobrevivir = sobrevivir;
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, .5f);
                Personaje.instance.Knockback();

            }
            controlarCanvas.instance.vercorazon();
        }
        
    }

    public void healPlayer() 
    {

        lowvida++;
        if (lowvida > fullvida)
        {
            lowvida = fullvida;
        }
        controlarCanvas.instance.vercorazon();
    }

}
