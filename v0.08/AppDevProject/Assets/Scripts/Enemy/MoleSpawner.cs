using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleSpawner : MonoBehaviour
{
    public GameObject MolePrefab;

    GameObject MoleClone;

    void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            // Debug.Log("M key is pressed");
            spawnrate();
            //Debug.Log("Kills from molespawner: " + GeneralPlayerActivities.Instance.mole_kills);
            EnemyAnimationDetection.Instance.totalEnemies += 1;
        }
    }

    private void spawnrate()
    {
        if (this.gameObject.tag == "even" && GeneralPlayerActivities.Instance.mole_kills % 2 == 0)
        {
            // MoleClone.tag = "even";
            //Debug.Log("even");
            MoleClone = Instantiate(MolePrefab, transform.position, Quaternion.identity) as GameObject;
        }
        else if (this.gameObject.tag == "odd" && GeneralPlayerActivities.Instance.mole_kills % 2 != 0)
        {
            // MoleClone.tag = "odd";
            //Debug.Log("odd");
            MoleClone = Instantiate(MolePrefab, transform.position, Quaternion.identity) as GameObject;
        }
    }
}
