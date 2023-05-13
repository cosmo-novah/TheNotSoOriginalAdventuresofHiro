using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public float DestroyTime = 3f;
    public GameObject ft;
    private int yaxis_min = 0;
    private int yaxis_max = 100;
    Vector3 Offset = new Vector3(0f, 1.25f, 0f);
    Vector3 goingUP = new Vector3(0f, 0.01f, 0f);
    Vector3 goingSMALL = new Vector3(0.005f, 0.005f, 0.005f);

    // Start is called before the first frame update
    void Start()
    {
        // transform.localPosition = new Vector3(0, 0, 0);
        transform.position += Offset;
        Debug.Log(transform.localPosition);
        Destroy(gameObject, DestroyTime);
        // transform.localPosition = Offset;
        // Debug.Log(transform.localPosition);
    }

    void FixedUpdate()
    {
        codedAnimation();
    }

    void codedAnimation()
    {
        if (yaxis_min != yaxis_max)
        {
            transform.position += goingUP;
            transform.localScale -= goingSMALL;
            yaxis_max++;
        }
    }
}
