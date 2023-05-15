using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class NextLevelScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ScenesManager.Instance.LoadNextLevel();
            Debug.Log("Next Level has been triggered");
            Vector3 teleport = new Vector3(-195.35f, 4.54f, 0);
            other.gameObject.GetComponent<Transform>().position = teleport;
        }
    }
}
