using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/HealthBuff")]
public class HealthBuff : PowerUpEffect
{
    public float amount;
    public override void Apply(GameObject target)
    {
        if (target.GetComponent<PlayerHealth>().health != 100)
        {
            Debug.Log(target.GetComponent<PlayerHealth>().health);
            target.GetComponent<PlayerHealth>().health += amount;
        }
    }

}
