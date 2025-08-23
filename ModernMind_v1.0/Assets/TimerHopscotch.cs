using UnityEngine;
using TMPro;
using System.Collections;

public class TimerHopscotch : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float remainingTime = 300f; // 5 minutes in seconds
    private bool isRunning = false; // Timer won't run until StartTimer() is called
    private bool isFrozen = false; // Added freeze flag

    public GameObject gameover, settings;

    void Update()
    {
        if (isRunning && !isFrozen) // ⬅ prevent counting down while frozen
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
            }
        }
    }

    // Function to start the countdown
    public void StartTimer()
    {
        remainingTime = 300f; // Reset to 5 minutes
        isRunning = true;
        isFrozen = false;
    }

    // Function to stop the timer
    public void StopTimer()
    {
        isRunning = false;
    }

    // Function to get current timer text
    public string GetTimerText()
    {
        return timerText.text;
    }

    // NEW: Freeze timer for X seconds
    public void FreezeTimerForSeconds(int seconds)
    {
        if (!isRunning) return; // no effect if timer not running
        StartCoroutine(FreezeCoroutine(seconds));
    }

    private IEnumerator FreezeCoroutine(int seconds)
    {
        isFrozen = true;
        yield return new WaitForSeconds(seconds); // waits in real time
        isFrozen = false;
    }
}
