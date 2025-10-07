using UnityEngine;
using TMPro;
using System.Collections;

public class TimerHopscotch : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float remainingTime = 300f; // 5 minutes in seconds
    private bool isRunning = false;
    private bool isFrozen = false;
    public float resetTime;

    public GameObject gameover, settings, freezeUI;

    void Update()
    {
        if (isRunning && !isFrozen)
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
                isRunning = false;
                timerText.text = "00:00";
                gameover.SetActive(true);
                settings.SetActive(false);
            }
        }
    }

    public void StartTimer()
    {
        remainingTime = resetTime;
        isRunning = true;
        isFrozen = false;
    }

    public void PauseTimer()
    {
        isRunning = false;
    }

    public void ContinueTimer()
    {
        isRunning = true;
    }

    public string GetTimerText()
    {
        return timerText.text;
    }

    public void FreezeTimerForSeconds(int seconds)
    {
        if (!isRunning) return;
        StartCoroutine(FreezeCoroutine(seconds));
    }

    private IEnumerator FreezeCoroutine(int seconds)
    {
        isFrozen = true;
        freezeUI.SetActive(true);
        yield return new WaitForSeconds(seconds);
        freezeUI.SetActive(false);
        isFrozen = false;
    }

    // NEW: Decrease remaining time
    public void DecreaseTime(float amount)
    {
        if (!isRunning) return;

        remainingTime -= amount;
        if (remainingTime < 0)
        {
            remainingTime = 0;
            isRunning = false;
            timerText.text = "00:00";
            gameover.SetActive(true);
            settings.SetActive(false);
        }
    }
}
