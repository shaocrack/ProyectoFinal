using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    //el tiempo para el respwan
    public float waitRespawn;
    //para los items y saber cuando recolectamos
    //gemscollectes =icosn
    public int iconsCollected;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //funcion para el respwan
    public void RespawnPlayer() 
    {
        StartCoroutine(RespawnCo());
    
    }
    //controlamos el respwan con los puntos
    IEnumerator RespawnCo() 
    {
    Personaje.instance.gameObject.SetActive(false);
    yield return new WaitForSeconds(waitRespawn);
      
    Personaje.instance.gameObject.SetActive(true);
    Personaje.instance.transform.position = checkController.instance.spawnPoint;  
    vida.instance.lowvida = vida.instance.fullvida;
    controlarCanvas.instance.vercorazon();

    }
}
