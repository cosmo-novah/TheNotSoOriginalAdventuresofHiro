using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Transform attackpoint;
    public GameObject player;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public Animator animator;
//<<<<<<< Updated upstream
    Collider2D m_C2D;
//=======
   public float swordDamage = 1f;

//>>>>>>> Stashed changes
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        // m_C2D = GetComponent<Collider2D>();
        // m_C2D.enabled = false;
        // var swing = player.GetComponent<Rigidbody2D>();
        // swing.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
    }

    //Update is called once per frame
    void Update()
    {
        // directionOfSword();

        if (Input.GetMouseButtonDown(0) /*&& gameObject.GetComponent<SpriteRenderer>().enabled == false*/)
        {
            // gameObject.GetComponent<SpriteRenderer>().enabled = true;
            var swing = player.GetComponent<Rigidbody2D>();
            // swing.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            swing.constraints = RigidbodyConstraints2D.FreezeAll;
            // swing.constraints = RigidbodyConstraints2D.FreezeRotation;
            // Debug.Log("Left Click");
            // m_C2D.enabled = true;
            clickToAttack_Sword();
        }
    }

    void clickToAttack_Sword()
    {
        // Play attack animation
        switch (PlayerMovement.Instance.direction)
        {
            case 1:
                PlayerMovement.Instance.animator.SetTrigger("Attack_North");
                break;
            case 2:
                PlayerMovement.Instance.animator.SetTrigger("Attack_East");
                break;
            case 3:
                PlayerMovement.Instance.animator.SetTrigger("Attack_South");
                break;
            case 4:
                PlayerMovement.Instance.animator.SetTrigger("Attack_West");
                break;
        }

        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackpoint.position, attackRange, enemyLayers);

        // Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
//<<<<<<< Updated upstream
            Debug.Log("We hit " + enemy.tag);
            Enemy.Instance.TakeDamage(1f);
            // var enmee = enemy.GetComponentInParent<GameObject>();
            // enmee.GetComponent<Enemy>().TakeDamage(1f);
//=======
            Debug.Log("We hit " + enemy.name);
            Enemy.Instance.TakeDamage(swordDamage);
//>>>>>>> Stashed changes
        }

        // m_C2D.enabled = !m_C2D.enabled;
    }

    void OnDrawGizmosSelected()
    {
        if (attackpoint == null)
            return;

        Gizmos.DrawWireSphere(attackpoint.position, attackRange);
    }

    void directionOfSword()
    {
        switch (PlayerMovement.Instance.direction)
        {
            case 1:
                animator.SetFloat("Sword_Idle_Right", -1);
                animator.SetFloat("Sword_Idle_South", -1);
                animator.SetFloat("Sword_Idle_West", -1);
                break;
            case 2:
                animator.SetFloat("Sword_Idle_Right", 1);
                animator.SetFloat("Sword_Idle_South", -1);
                animator.SetFloat("Sword_Idle_West", -1);
                break;
            case 3:
                animator.SetFloat("Sword_Idle_Right", -1);
                animator.SetFloat("Sword_Idle_South", 1);
                animator.SetFloat("Sword_Idle_West", -1);
                break;
            case 4:
                animator.SetFloat("Sword_Idle_Right", -1);
                animator.SetFloat("Sword_Idle_South", -1);
                animator.SetFloat("Sword_Idle_West", 1);
                break;
        }
    }

    void endAnimation()
    {
        Debug.Log("Animation is done");
        // m_C2D.enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        var swing = player.GetComponent<Rigidbody2D>();
        swing.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
        swing.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
    }
}
