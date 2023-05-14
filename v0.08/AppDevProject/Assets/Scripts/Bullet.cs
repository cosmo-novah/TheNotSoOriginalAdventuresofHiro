using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static Bullet Instance;
    [SerializeField] private float damage = 50f;

    public Animator animator;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroys the bullet
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            enemyComponent.TakeDamage(damage);
            Debug.Log("Hit enemy");
        }
        Destroy(gameObject);

        // if (collision.gameObject.tag == "Enemy")
        // {
        //     Enemy.Instance.TakeDamage(damage);
        //     Debug.Log("Hit enemy");
        // }
    }

    public void resetAnimation()
    {
        animator.SetFloat("FB_North", 0);
        animator.SetFloat("FB_East", 0);
        animator.SetFloat("FB_South", 0);
        animator.SetFloat("FB_West", 0);
    }

    /*
        private void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.tag == "Enemy")
            {
                other.GetComponent<Enemy>().TakeDamage(damage);
                Debug.Log("Enemy hit");
            }
        }

       */
}
