using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy Instance;
    GeneralPlayerActivities GPA;
    public Animator animator;
    public float speed = 3f;
    public bool willStep = true;
    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float attackSpeed = 0.5f;
    [SerializeField] private float health, maxHealth = 100f;
    public int[] healthy;
    private float canAttack;
    public Transform target;
    public int anibox;
    public float step;
    private float timer;
    // public Rigidbody2D rb2d;     // had to comment out
    //public GameObject player;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        // else if (Instance != null)
        // {
        //     Debug.Log("Instance already exists, destroying object!");
        //     Destroy(this);
        // }
    }
    private void Start()
    {
        health = maxHealth;
    }

    private void FixedUpdate()
    {
        //If there is no target and the player enters range then the enemy will move towards the players position
        if (target != null && willStep)
        {
            step = (speed * Time.deltaTime) / 1.5f;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
        //Having canAttack here lets enemies "reload" without being in contact with the player
        canAttack += Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        //Attack damage and resets the attack time to 0
        // Debug.Log("Staying");
        if (other.gameObject.tag == "Player")
        {
            if (attackSpeed <= canAttack)
            {
                other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                canAttack = 0f;
                switch (EnemyAnimationDetection.Instance.MTA_VAR)
                {
                    case 1:
                        Debug.Log(EnemyAnimationDetection.Instance.trigger_point);
                        Vector3 kbN = new Vector3(0f, 1.25f, 0f);
                        other.gameObject.GetComponent<Transform>().position += kbN;
                        break;
                    case 2:
                        Debug.Log(EnemyAnimationDetection.Instance.trigger_point);
                        Vector3 kbE = new Vector3(1.25f, 0f, 0f);
                        other.gameObject.GetComponent<Transform>().position += kbE;
                        break;
                    case 3:
                        Debug.Log(EnemyAnimationDetection.Instance.trigger_point);
                        Vector3 kbS = new Vector3(0f, -1.25f, 0f);
                        other.gameObject.GetComponent<Transform>().position += kbS;
                        break;
                    case 4:
                        Debug.Log(EnemyAnimationDetection.Instance.trigger_point);
                        Vector3 kbW = new Vector3(-1.25f, 0f, 0f);
                        other.gameObject.GetComponent<Transform>().position += kbW;
                        break;
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Creates target when player is in range
        if (other.gameObject.tag == "Player")
        {
            target = other.transform;
            EnemyAnimationDetection.Instance.idle = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Wipes target when player is out of range
        if (other.gameObject.tag == "Player")
        {
            target = null;
            EnemyAnimationDetection.Instance.idle = true;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        // Determines which way the enemy will be knocked back when hit
        switch (PlayerMovement.Instance.direction)
        {
            case 1:
                Vector3 kbN = new Vector3(0f, 0.5f, 0f);
                transform.position += kbN;
                break;
            case 2:
                Vector3 kbE = new Vector3(0.5f, 0f, 0f);
                transform.position += kbE;
                break;
            case 3:
                Vector3 kbS = new Vector3(0f, -0.5f, 0f);
                transform.position += kbS;
                break;
            case 4:
                Vector3 kbW = new Vector3(-0.5f, 0f, 0f);
                transform.position += kbW;
                break;
        }

        if (health <= 0f)
        {
            // Debug.Log(health);
            GeneralPlayerActivities.Instance.mole_kills++;
            Debug.Log("Kills: " + GeneralPlayerActivities.Instance.mole_kills);
            Die();
        }
    }

    public void Die()
    {
        GetComponent<LootBag>().InstantiateLoot(transform.position);
        Destroy(gameObject);
        Debug.Log("Enemy Died");
    }
}