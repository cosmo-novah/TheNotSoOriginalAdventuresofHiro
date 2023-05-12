using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerUpEffect powerEffect;

     private void OnTriggerEnter2D(Collider2D collision)
     {
         if (collision.CompareTag("Player"))
         {      
             Destroy(gameObject);
             powerEffect.Apply(collision.gameObject);
         }
     }
}
