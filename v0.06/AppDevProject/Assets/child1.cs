using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class child1 : MonoBehaviour
{
    public static child1 Instance;

    public void Awake()
    {
        Instance = this;
    }

    public void text()
    {
        Debug.Log("you have reached the child object");

    }
}
