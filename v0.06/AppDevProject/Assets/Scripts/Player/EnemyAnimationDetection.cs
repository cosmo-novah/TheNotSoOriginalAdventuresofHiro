using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationDetection : MonoBehaviour
{
    public static EnemyAnimationDetection Instance;
    //Enemy enemy;
    // public BoxCollider2D[] boxCols2D;
    public int trigger_point;
    public int MTA_VAR;
    public bool idle = true;
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
            switch (MTA_VAR)
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
}
