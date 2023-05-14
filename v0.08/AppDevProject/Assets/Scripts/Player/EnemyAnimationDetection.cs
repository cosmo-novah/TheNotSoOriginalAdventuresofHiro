using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationDetection : MonoBehaviour
{
    public static EnemyAnimationDetection Instance;
    //Enemy enemy;
    // public BoxCollider2D[] boxCols2D;
    // [SerializeField] public int trigger_point = 1;
    public int trigger_point;
    public int MTA_VAR;
    public bool idle = true;
    public int totalEnemies;
    public Animator animator;
    public Transform player;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkIfIdle();
        setEnemyDirection();
    }

    void checkIfIdle()
    {
        if (idle)
        {
            switch (trigger_point)
            {
                case 1:
                    animator.SetFloat("Walk_North", -1);
                    animator.SetFloat("Walk_East", 0);
                    animator.SetFloat("Walk_South", 0);
                    animator.SetFloat("Walk_West", 0);
                    break;
                case 2:
                    animator.SetFloat("Walk_North", 0);
                    animator.SetFloat("Walk_East", -1);
                    animator.SetFloat("Walk_South", 0);
                    animator.SetFloat("Walk_West", 0);
                    break;
                case 3:
                    animator.SetFloat("Walk_North", 0);
                    animator.SetFloat("Walk_East", 0);
                    animator.SetFloat("Walk_South", -1);
                    animator.SetFloat("Walk_West", 0);
                    break;
                case 4:
                    animator.SetFloat("Walk_North", 0);
                    animator.SetFloat("Walk_East", 0);
                    animator.SetFloat("Walk_South", 0);
                    animator.SetFloat("Walk_West", -1);
                    break;
            }
        }
    }

    void setEnemyDirection()
    {
        if (!idle)
        {
            switch (trigger_point)
            {
                case 1:
                    MTA_VAR = 1;
                    animator.SetFloat("Walk_North", 1);
                    animator.SetFloat("Walk_East", 0);
                    animator.SetFloat("Walk_South", 0);
                    animator.SetFloat("Walk_West", 0);
                    break;
                case 2:
                    MTA_VAR = 2;
                    animator.SetFloat("Walk_North", 0);
                    animator.SetFloat("Walk_East", 1);
                    animator.SetFloat("Walk_South", 0);
                    animator.SetFloat("Walk_West", 0);
                    break;
                case 3:
                    MTA_VAR = 3;
                    animator.SetFloat("Walk_North", 0);
                    animator.SetFloat("Walk_East", 0);
                    animator.SetFloat("Walk_South", 1);
                    animator.SetFloat("Walk_West", 0);
                    break;
                case 4:
                    MTA_VAR = 4;
                    animator.SetFloat("Walk_North", 0);
                    animator.SetFloat("Walk_East", 0);
                    animator.SetFloat("Walk_South", 0);
                    animator.SetFloat("Walk_West", 1);
                    break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Creates target when player is in range
        if (other.gameObject.tag == "Player")
        {
            idle = false;
            player = other.gameObject.GetComponent<Transform>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Wipes target when player is out of range
        if (other.gameObject.tag == "Player")
        {
            idle = true;
            player = null;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        //Creates target when player is in range
        if (other.gameObject.tag == "Player")
        {
            Vector3 enemyDirectionLocal = player.InverseTransformPoint(transform.position);
            if (enemyDirectionLocal.x > 0)
            {
                trigger_point = 4;
            }
            else if (enemyDirectionLocal.x < 0)
            {
                trigger_point = 2;
            }

            if (enemyDirectionLocal.y > 0 && enemyDirectionLocal.x > 0)
            {
                trigger_point = 3;
            }
            else if (enemyDirectionLocal.y < 0 && enemyDirectionLocal.x < 0)
            {
                trigger_point = 1;
            }
        }
    }
}
