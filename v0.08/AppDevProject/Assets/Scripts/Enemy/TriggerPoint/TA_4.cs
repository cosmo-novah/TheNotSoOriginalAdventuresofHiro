using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TA_4 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            EnemyAnimationDetection.Instance.trigger_point = 4;
        }
        // Debug.Log("Trigger Point 4");
    }
}
