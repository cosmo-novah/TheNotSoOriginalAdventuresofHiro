using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/SpeedBuff")]
public class SpeedBuff : PowerUpEffect
{
    public float amount;

    public override void Apply(GameObject target)
    {
        if (target.GetComponent<PlayerMovement>().moveSpeed < 8) //added line to cap speed 
        {
            target.GetComponent<PlayerMovement>().moveSpeed += amount;
        }
    }

}
