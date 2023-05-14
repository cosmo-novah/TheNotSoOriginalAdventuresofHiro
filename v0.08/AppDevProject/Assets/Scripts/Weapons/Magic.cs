using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Stuff for Magic")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public GameObject player;
    public static Magic magic;

    public void Awake()
    {
        magic = this;
    }

    public float fireForce = 20f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var swing = player.GetComponent<Rigidbody2D>();
            swing.constraints = RigidbodyConstraints2D.FreezeAll;
            castSpell();
        }
        UpdatePosition();
    }

    public void Fire()
    {
        // Bullet.Instance.animator.SetFloat("FB_North", 1);
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
        switch (PlayerMovement.Instance.direction)
        {
            case 1:
                // Bullet.Instance.resetAnimation();
                Bullet.Instance.animator.SetFloat("FB_North", 1);
                Bullet.Instance.animator.SetFloat("FB_East", 0);
                Bullet.Instance.animator.SetFloat("FB_South", 0);
                Bullet.Instance.animator.SetFloat("FB_West", 0);
                break;
            case 2:
                // Bullet.Instance.resetAnimation();
                Bullet.Instance.animator.SetFloat("FB_East", 1);
                break;
            case 3:
                // Bullet.Instance.resetAnimation();
                Bullet.Instance.animator.SetFloat("FB_South", 1);
                break;
            case 4:
                // Bullet.Instance.resetAnimation();
                Bullet.Instance.animator.SetFloat("FB_East", 1);
                break;
        }
    }

    public void UpdatePosition()
    {
        int pointing = PlayerMovement.Instance.direction;
        switch (pointing)
        {
            case 1:
                //Rotates
                Vector3 rotationN = new Vector3(0f, 0f, 0f);
                transform.localEulerAngles = rotationN;
                //Repositions
                Vector3 positionN = new Vector3(0.4f, 3.71f, 0f);
                transform.localPosition = positionN;
                break;
            case 2:
                //Rotates
                Vector3 rotationE = new Vector3(0f, 0f, -90f);
                transform.localEulerAngles = rotationE;
                //Repositions
                Vector3 positionE = new Vector3(4f, -1.5f, 0f);
                transform.localPosition = positionE;
                break;
            case 3:
                //Rotates
                Vector3 rotationS = new Vector3(0f, 0f, -180f);
                transform.localEulerAngles = rotationS;
                //Repositions
                Vector3 positionS = new Vector3(0.4f, -6.71f, 0f);
                transform.localPosition = positionS;
                break;
            case 4:
                //Rotates
                Vector3 rotationW = new Vector3(0f, 0f, -270f);
                transform.localEulerAngles = rotationW;
                //Repositions
                Vector3 positionW = new Vector3(-4f, -1.5f, 0f);
                transform.localPosition = positionW;
                break;
        }
    }

    public void castSpell()
    {
        // Play attack animation
        switch (PlayerMovement.Instance.direction)
        {
            case 1:
                PlayerMovement.Instance.animator.SetTrigger("Magic_North");
                break;
            case 2:
                PlayerMovement.Instance.animator.SetTrigger("Magic_East");
                break;
            case 3:
                PlayerMovement.Instance.animator.SetTrigger("Magic_South");
                break;
            case 4:
                PlayerMovement.Instance.animator.SetTrigger("Magic_West");
                break;
        }
    }

    public void endAnimation_Magic()
    {
        Debug.Log("Animation is done");
        Fire();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        var swing = player.GetComponent<Rigidbody2D>();
        swing.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
        swing.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
        // swing.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}