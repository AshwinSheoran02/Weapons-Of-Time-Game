using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float totalTime = 60f;  // Total time in seconds
    private float currentTime;    // Current time in seconds
    public TextMeshProUGUI timerText;

    private void Start()
    {
        currentTime = totalTime;
        UpdateTimerText();
    }

    private void Update()
    {
        if (currentTime > 0f)
        {
            currentTime -= Time.deltaTime;
            if (currentTime < 0f)
            {
                currentTime = 0f;
            }
            UpdateTimerText();
        }
    }

    private void UpdateTimerText()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(currentTime / 60f);
            int seconds = Mathf.FloorToInt(currentTime % 60f);
            string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
            timerText.text = "Time: " + timeString;
        }
    }
}
