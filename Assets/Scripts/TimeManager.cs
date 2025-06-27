using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private Text timerText;

    [SerializeField]
    private float startTime = 300f;

    private float timeLeft;

    private bool isRunning = false;

    private void Start()
    {
        isRunning = true;
        timeLeft = startTime;
    }

    private void Update()
    {
        if(isRunning)
        {
            timeLeft -= Time.deltaTime;
            if(timeLeft <= 0.0f)
            {
                isRunning = false;
                return;
            }
            UpdateTimer();
        }
    }

    private void UpdateTimer()
    {
        int minutes = Mathf.FloorToInt(timeLeft / 60f);
        int seconds = Mathf.FloorToInt(timeLeft % 60f);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
