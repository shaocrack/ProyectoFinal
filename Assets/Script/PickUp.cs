using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    //para definir que tipo es
    public bool isCoin;
    public bool isheart;
    //para evitar confuciones
    private bool isCollected;
    public GameObject pickupEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (isCoin)
            {
                LevelManager.instance.iconsCollected++;
                controlarCanvas.instance.UpdateCoinCount();
                Instantiate(pickupEffect, transform.position, transform.rotation); 
                isCollected = true;
                Destroy(gameObject);
            }
            if (isheart)
            {
                if (vida.instance.lowvida !=vida.instance.fullvida)
                {
                    vida.instance.healPlayer();
                    isCollected=true;
                    Destroy(gameObject);
                }
            }
        }

    }

}
