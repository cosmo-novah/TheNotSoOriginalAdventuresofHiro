using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorway : MonoBehaviour
{
    public Transform Spawnpoint;
    public GameObject Prefab;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision in Doorway");
      
        if(other.CompareTag("Wall"))
        {
            Debug.Log("Wall Detected");
            Instantiate(Prefab, Spawnpoint.position, Spawnpoint.rotation);
        }
    }
}
