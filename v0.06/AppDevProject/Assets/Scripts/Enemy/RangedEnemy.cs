using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour {
    public Transform target;
    public float speed = 3f;
    public float rotateSpeed = 0.025f;
    private Rigidbody2D rb;
    public GameObject bulletPrefab;

    public float distanceToShoot = 5f;
    public float distanceToStop = 3f;

    public float fireRate;
    private float timeToFire;

    [SerializeField] public Transform firingPoint;
    public float fireForce = 20f;

    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float health;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

    private void Update() {
        if (!target) {
            GetTarget();
        } else {
            RotateTowardsTarget();
        }
        
    }

    private void Shoot() {
        if (timeToFire <= 0f) {
            GameObject enemyBullet = Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
            enemyBullet.GetComponent<Rigidbody2D>().AddForce(firingPoint.up * fireForce, ForceMode2D.Impulse);
            timeToFire = fireRate;
        } else {
            timeToFire -= Time.deltaTime;
        }
    }

    private void FixedUpdate() {
        if (target != null) {
            if (Vector2.Distance(target.position, transform.position) >= distanceToStop) {
                rb.velocity = transform.up * speed;
            } else {
                rb.velocity = Vector2.zero;
            }
        }
        if (target != null && Vector2.Distance(target.position, transform.position) <= distanceToShoot) {
            Shoot();
        }
    }

    private void RotateTowardsTarget() {
        Vector2 targetDirection = target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
    }

    private void GetTarget() {
        if (GameObject.FindGameObjectWithTag("Player")){
        target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            Destroy(other.gameObject);
            target = null;
        } /*else if (other.gameObject.CompareTag("Bullet")) {
            Destroy(gameObject);
        }*/
    }

    public void TakeDamage(float damage) 
    {
        health -= damage;

        if (health <= 0f)
        {
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