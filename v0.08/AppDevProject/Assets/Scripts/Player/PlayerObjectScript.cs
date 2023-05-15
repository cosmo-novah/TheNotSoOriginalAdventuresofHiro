using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectScript : MonoBehaviour
{
    public GameObject player;
    public GameObject FloatingTextPrefab;

    public static PlayerObjectScript Instance;

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

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
