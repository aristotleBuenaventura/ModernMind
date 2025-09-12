using UnityEngine;
using TMPro;

public class TimerDisplay : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float remainingTime = 300f; // 5 minutes in seconds
    private bool isRunning = false; // Timer won't run until StartTimer() is called
    public GameObject gameover, settings;

    void Update()
    {
        if (isRunning)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;

                int minutes = Mathf.FloorToInt(remainingTime / 60);
                int seconds = Mathf.FloorToInt(remainingTime % 60);

                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
            else
            {
                remainingTime = 0;
                isRunning = false; // Stop when it hits 0
                timerText.text = "00:00";
                gameover.SetActive(true);
                settings.SetActive(false);
                // (Optional) You can trigger an event here when the timer reaches zero
            }
        }
    }

    // Function to start the countdown
    public void StartTimer()
    {
        remainingTime = 300f; // Reset to 5 minutes
        isRunning = true;
    }

    // Function to pause the timer
    public void PauseTimer()
    {
        isRunning = false;
    }

    // Function to resume the timer
    public void ResumeTimer()
    {
        isRunning = true;
    }

    // Function to get current timer text
    public string GetTimerText()
    {
        return timerText.text;
    }
}
