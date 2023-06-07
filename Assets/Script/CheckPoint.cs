using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    //
    public SpriteRenderer thSR;
    public Sprite cpOn, cpOff;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            checkController.instance.DeactivateCheckPont(); ;
            thSR.sprite = cpOn;
            //para guardar cuando lo golpeamos
            checkController.instance.SetSpawnPoint(transform.position);
        }
    }
    public void ResetCheckpoint() 
    {
        thSR.sprite = cpOff;


    }
}
