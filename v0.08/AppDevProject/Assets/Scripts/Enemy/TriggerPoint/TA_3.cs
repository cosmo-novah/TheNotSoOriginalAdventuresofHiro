using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TA_3 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // EnemyAnimationDetection.Instance.trigger_point = 3;
        }
        // Debug.Log("Trigger Point 3");
    }
}
