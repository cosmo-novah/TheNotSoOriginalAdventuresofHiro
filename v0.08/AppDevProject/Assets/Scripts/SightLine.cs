using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightLine : Enemy
{
        private void OnTriggerEnter2D(Collider2D other) {
        //Creates target when player is in range
        if (other.gameObject.tag == "Player")
        {
            base.target = other.transform;
            Debug.Log("Player detected");
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        //Wipes target when player is out of range
        if (other.gameObject.tag == "Player") {
            base.target = null;
            Debug.Log("Player left sightline");
        }
    }
}
