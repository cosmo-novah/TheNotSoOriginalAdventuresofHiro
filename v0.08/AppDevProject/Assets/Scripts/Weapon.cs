using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject Gun;
    public GameObject Sword;
    public GameObject Player;
    bool rotatedHorizontal = true;
    bool rotatedVertical = true;
    // private float cooldown = 0f;
    // public Transform attackpoint;
    // public float attackRange = 0.5f;
    // public LayerMask enemyLayers;
    private void Start()
    {
        // Sword.SetActive(false);
    }

    private void Update()
    {
        // if (Input.GetMouseButtonDown(0))
        // {
        //     Debug.Log("Left Moust Click");
        //     clickToAttack_Sword();
        // }
        // // onDrawGizmosSelected();
    }

    private void FixedUpdate()
    {
        positionWeapon();
    }

    // void positionWeapon()
    // {
    //     Vector3 posN = Player.transform.position;

    //     switch (PlayerMovement.Instance.direction)
    //     {
    //         case 1:     // faces weapon North
    //             if (!rotatedVertical)
    //             {
    //                 Vector3 newRotation = new Vector3(0, 0, 45);
    //                 Sword.transform.eulerAngles = newRotation;
    //                 // Vector3 newScale = Sword.transform.localScale;
    //                 // newScale.Set(1, 1, 1);
    //                 // Sword.transform.localScale = newScale;
    //             }
    //             rotateY();
    //             Vector3 newPositionN = new Vector3(posN.x, posN.y + 1f, 0f);
    //             Sword.transform.position = newPositionN;
    //             Debug.Log("North");
    //             break;
    //         case 2:     // faces weapon East
    //             if (!rotatedHorizontal)
    //             {
    //                 Vector3 newRotation = new Vector3(0, 0, 315);
    //                 Sword.transform.eulerAngles = newRotation;
    //                 // Vector3 newScale = Sword.transform.localScale;
    //                 // newScale.Set(1, 1, 1);
    //                 // Sword.transform.localScale = newScale;
    //             }
    //             rotateH();
    //             Vector3 newPositionE = new Vector3(posN.x + 1f, posN.y - 0.125f, 0f);
    //             Sword.transform.position = newPositionE;
    //             Debug.Log("East");
    //             break;
    //         case 3:     // faces weapon South
    //             if (rotatedVertical)
    //             {
    //                 Vector3 newRotation = new Vector3(0, 0, 225);
    //                 Sword.transform.eulerAngles = newRotation;
    //                 // Vector3 newScale = Sword.transform.localScale;
    //                 // newScale.Set(1, 1, 1);
    //                 // Sword.transform.localScale = newScale;
    //             }
    //             rotateY();
    //             Vector3 newPositionS = new Vector3(posN.x, posN.y - 1f, 0f);
    //             Sword.transform.position = newPositionS;
    //             Debug.Log("South");
    //             break;
    //         case 4:     // faces weapon West
    //             if (rotatedHorizontal)
    //             {
    //                 Vector3 newRotation = new Vector3(0, 0, 405);      // z = -225
    //                 Sword.transform.eulerAngles = newRotation;
    //                 // Vector3 newScale = Sword.transform.localScale;
    //                 // newScale.Set(-1, 1, 1);
    //                 // Sword.transform.localScale = newScale;
    //                 // Debug.Log(Sword.transform.localScale);
    //             }
    //             rotateH();
    //             Vector3 newPositionW = new Vector3(posN.x - 1f, posN.y - 0.125f, 0f);
    //             Sword.transform.position = newPositionW;
    //             Debug.Log("West");
    //             break;
    //     }
    // }

    void positionWeapon()
    {
        Vector3 posN = Player.transform.position;

        switch (PlayerMovement.Instance.direction)
        {
            case 1:     // faces weapon North
                Vector3 newRotationN = new Vector3(0, 0, 0);
                Sword.transform.eulerAngles = newRotationN;
                Vector3 newPositionN = new Vector3(posN.x, posN.y + 1f, 0f);
                Sword.transform.position = newPositionN;
                // Debug.Log("North");
                break;
            case 2:     // faces weapon East
                Vector3 newRotationE = new Vector3(0, 0, -90);
                Sword.transform.eulerAngles = newRotationE;
                Vector3 newPositionE = new Vector3(posN.x + 1f, posN.y - 0.125f, 0f);
                Sword.transform.position = newPositionE;
                // Debug.Log("East");
                break;
            case 3:     // faces weapon South
                Vector3 newRotationS = new Vector3(0, 0, -180);
                Sword.transform.eulerAngles = newRotationS;
                Vector3 newPositionS = new Vector3(posN.x, posN.y - 1f, 0f);
                Sword.transform.position = newPositionS;
                // Debug.Log("South");
                break;
            case 4:     // faces weapon West
                // Vector3 newRotationW = new Vector3(0, 0, Mathf.Abs(135f));      // z = -225
                // Sword.transform.eulerAngles = newRotationW;
                Sword.transform.rotation = Quaternion.Euler(0, 0, -270);
                Vector3 newPositionW = new Vector3(posN.x - 1f, posN.y - 0.125f, 0f);
                Sword.transform.position = newPositionW;
                // Debug.Log("West");
                break;
        }
    }

    void rotateH()
    {
        rotatedHorizontal = !rotatedHorizontal;
    }

    void rotateY()
    {
        rotatedVertical = !rotatedVertical;
    }

    // void weaponCooldown()
    // {
    //     if (cooldown > 0)
    //     {
    //         cooldown -= Time.deltaTime;
    //         // Debug.Log(cooldown);
    //     }
    // }

    // void clickToAttack_Sword()
    // {
    //     // Play attack animation


    //     // Detect enemies in range of attack
    //     Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackpoint.position, attackRange, enemyLayers);

    //     // Damage them
    //     foreach (Collider2D enemy in hitEnemies)
    //     {
    //         Debug.Log("We hit " + enemy.name);
    //     }
    // }

    // void OnDrawGizmosSelected()
    // {
    //     if (attackpoint == null)
    //         return;

    //     Gizmos.DrawWireSphere(attackpoint.position, attackRange);
    // }

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (Input.GetMouseButtonDown(0) && other.gameObject.tag == "Hitbox")
    //     {
    //         Debug.Log("One enemy hit!");
    //     }
    // }
}

