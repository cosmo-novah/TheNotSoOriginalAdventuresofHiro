using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverScreen : MonoBehaviour
{
    // ADD POINTS SYSTEM TO SHOW ON GAME OVER

    public void Setup()
    {
        // gameObject.SetActive(true);
        Time.timeScale = 0f;
        UIManager.instance.OameOverScreen();
    }
    public void RestartButton()
    {
        Time.timeScale = 1f;
        //ScenesManager.Instance.LoadNewGame();
        SceneManager.LoadScene("SampleScene");
        Debug.Log("Restart From Game Over Screen");
    }

    public void MenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");
        Debug.Log("Go Main Menu From Game Over Screen");
    }

    public void SaveButton()
    {
        Time.timeScale = 1f;
        // GeneralPlayerActivities.Instance.saveButton = 1;
        var GPA = GeneralPlayerActivities.Instance;
        var TIME = Timer.time;
        FirebaseManager.FBM.SaveDataButton(GPA.username, GPA.wallet, GPA.mole_kills, GPA.totalDeaths, GPA.totalTime);
        // UIManager.instance.UserDataScreen();
        // SceneManager.LoadScene("Scoreboard");
        //UIManager.instance.ScoreboardScreen();
    }

}
