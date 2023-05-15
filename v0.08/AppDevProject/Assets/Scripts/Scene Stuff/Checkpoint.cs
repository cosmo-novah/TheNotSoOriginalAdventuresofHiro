using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
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
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (other.gameObject.tag == "Player")
        {
            if (sceneName == "SampleScene" && ScenesManager.Instance.checkpoint == 5)
            {
                ScenesManager.Instance.LoadScene(ScenesManager.Scenes.SampleScene);
                Debug.Log("Next Level has been triggered");
                Vector3 teleportL5 = new Vector3(-195.35f, 4.54f, 0);
                other.gameObject.GetComponent<Transform>().position = teleportL5;
                Debug.Log("NOW IN LEVEL 5");
            }
            else if (sceneName == "Level_5" && ScenesManager.Instance.checkpoint == 5)
            {
                ScenesManager.Instance.LoadScene(ScenesManager.Scenes.SampleScene);
                Debug.Log("Next Level has been triggered");
                Vector3 teleport = new Vector3(-195.35f, 4.54f, 0);
                other.gameObject.GetComponent<Transform>().position = teleport;
                Debug.Log("NOW IN OVERWORLD");
            }
            else if (sceneName == "SampleScene" && ScenesManager.Instance.checkpoint == 0)
            {
                ScenesManager.Instance.LoadNextLevel();
                Debug.Log("Next Level has been triggered");
                Vector3 teleport = new Vector3(-195.35f, 4.54f, 0);
                other.gameObject.GetComponent<Transform>().position = teleport;
                Debug.Log("NOW IN DUNGEON");
            }
        }
    }
}