using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Magic weapon;

    private Vector2 mousePosition;
    private Vector2 movement;
    public Animator animator;
    public int direction = 0;
    public bool idle = false;
    public static PlayerMovement Instance;
    public void Awake()
    {
        Instance = this;
    }
    //Use Update for physics
    void Update()
    {
        MovementInput();
        playerMoving();
        playerIdle();
        //mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    //Use FixedUpdate for inputs
    void FixedUpdate()
    {
        rb.velocity = (movement * moveSpeed) / 1.5f;

        /*Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;*/
    }
    //Horizontal and Vertical are built into unity
    void MovementInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (moveX != 0 && moveY == 0)
        {
            switch (moveX)
            {
                case 1:     // moving East
                    direction = 2;
                    break;
                case -1:    // moving West
                    direction = 4;
                    break;
            }
        }

        if (moveX == 0 && moveY != 0)
        {
            switch (moveY)
            {
                case 1:     // moving North
                    direction = 1;
                    break;
                case -1:    // moving South
                    direction = 3;
                    break;
            }
        }

        if (moveX == 0 && moveY == 0)
        {
            idle = true;
        }
        else
        {
            idle = false;
        }

        //Normalized keeps the diagnol movement the same speed as the pure horizontal and vertical
        movement = new Vector2(moveX, moveY).normalized;
    }

    void playerMoving()
    {
        if (!idle)
        {
            // Debug.Log("NOT Idle");
            switch (direction)
            {
                case 1:
                    animator.SetFloat("Up", 1);
                    animator.SetFloat("Right", 0);
                    animator.SetFloat("South", 0);
                    animator.SetFloat("Left", 0);
                    break;
                case 2:
                    animator.SetFloat("Up", 0);
                    animator.SetFloat("Right", 1);
                    animator.SetFloat("South", 0);
                    animator.SetFloat("Left", 0);
                    break;
                case 3:
                    animator.SetFloat("Up", 0);
                    animator.SetFloat("Right", 0);
                    animator.SetFloat("South", 1);
                    animator.SetFloat("Left", 0);
                    break;
                case 4:
                    animator.SetFloat("Up", 0);
                    animator.SetFloat("Right", 0);
                    animator.SetFloat("South", 0);
                    animator.SetFloat("Left", 1);
                    break;
            }
        }
    }

    void playerIdle()
    {
        if (idle)
        {
            // Debug.Log("Idle");
            switch (direction)
            {
                case 1:
                    animator.SetFloat("Up", -1);
                    animator.SetFloat("Right", 0);
                    animator.SetFloat("South", 0);
                    animator.SetFloat("Left", 0);
                    break;
                case 2:
                    animator.SetFloat("Up", 0);
                    animator.SetFloat("Right", -1);
                    animator.SetFloat("South", 0);
                    animator.SetFloat("Left", 0);
                    break;
                case 3:
                    animator.SetFloat("Up", 0);
                    animator.SetFloat("Right", 0);
                    animator.SetFloat("South", -1);
                    animator.SetFloat("Left", 0);
                    break;
                case 4:
                    animator.SetFloat("Up", 0);
                    animator.SetFloat("Right", 0);
                    animator.SetFloat("South", 0);
                    animator.SetFloat("Left", -1);
                    break;
            }
        }
    }

    public void endAnimation_Magic()
    {
        Magic.magic.endAnimation_Magic();
    }
}
