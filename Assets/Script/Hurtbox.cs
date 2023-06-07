using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    public GameObject deathEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Enemy")
        {
            other.transform.parent.gameObject.SetActive(false);
            Instantiate(deathEffect,other.transform.position,other.transform.rotation);
        }
    }
}
