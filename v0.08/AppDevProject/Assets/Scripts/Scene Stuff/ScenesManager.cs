using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public int checkpoint = 0;

    public static ScenesManager Instance;

    public void Awake()
    {
        Instance = this;
    }

    public void FixedUpdate()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        switch (sceneName)
        {
            case "Level_5":
                checkpoint = 5;
                break;
        }
    }

    // WHEN NEW SCENES ARE ADDED:
    // MAKE SURE IT IS ADDED TO THIS AND
    // THEY ARE IN THE SAME ORDER AS THEY ARE IN THE BUILD SETTINGS
    public enum Scenes
    {
        StartMenu,
        // Login,
        //Scoreboard,
        SampleScene,
        Level_1,
        Level_2,
        Level_3,
        Level_4,
        Level_5,
        Level_6,
        Level_7,
        Level_8,
        Level_9,
        Level_10,

        LevelTwo
    }

    public void LoadScene(Scenes scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public void LoadNewGame()
    {
        SceneManager.LoadScene(Scenes.SampleScene.ToString());
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Scenes.StartMenu.ToString());

    }
}
