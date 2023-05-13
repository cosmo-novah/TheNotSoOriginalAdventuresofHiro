using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;

// VIDEO USED AS REFERENCE:
// https://www.youtube.com/watch?v=HLz_k6DSQvU&ab_channel=CocoCode

public class Timer : MonoBehaviour
{
    public static Timer time;
    bool timerActive = false;
    public float currentTime;
    public int startMinutes;
    public TMP_Text currentTimeText;

    public void Awake()
    {
        time = this;
    }

    void Start()
    {
        currentTime = startMinutes * 60;
    }

    void Update()
    {
        startTimer();
        if (timerActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
            if (currentTime <= 0)
            {
                Start();
                Debug.Log("timer finished");
            }
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        // currentTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString() + ":" + time.Milliseconds.ToString();
        currentTimeText.text = time.ToString(@"mm\:ss\:fff");
        stopTimer();
    }

    public void startTimer()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName != "StartMenu")
        {
            timerActive = true;
        }
    }

    public void stopTimer()
    {
        timerActive = false;
    }
}
