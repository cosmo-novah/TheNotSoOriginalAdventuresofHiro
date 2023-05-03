using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance;

    public void Awake()
    {
        Instance = this;
    }

    // WHEN NEW SCENES ARE ADDED:
    // MAKE SURE IT IS ADDED TO THIS AND
    // THEY ARE IN THE SAME ORDER AS THEY ARE IN THE BUILD SETTINGS
    public enum Scene
    {
        StartMenu,
        // Login,
        //Scoreboard,
        SampleScene,
        LevelOne,
        LevelTwo
    }

    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public void LoadNewGame()
    {
        SceneManager.LoadScene(Scene.SampleScene.ToString());
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Scene.StartMenu.ToString());

    }
}
