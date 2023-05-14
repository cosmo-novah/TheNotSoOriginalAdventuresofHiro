using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainmenu : MonoBehaviour
{
    public void PlayGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        ScenesManager.Instance.LoadNextScene();
        Debug.Log("Game has restarted");
        //Destroy(GameObject.Find("- Player -"));
    }

    public void QuitGame()
    {
        Debug.Log("QUIT WORKED");
        Application.Quit();
    }
}
