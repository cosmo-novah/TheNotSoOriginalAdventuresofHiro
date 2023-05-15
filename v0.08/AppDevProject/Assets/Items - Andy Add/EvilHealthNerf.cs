using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/Nerf")]
public class EvilHealthNerf : PowerUpEffect
{
    public float amount;

    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerHealth>().health += amount;
    }
}
