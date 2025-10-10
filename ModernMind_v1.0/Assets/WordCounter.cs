using UnityEngine;

public class WordCounter : MonoBehaviour
{
    private int counter;
    public int wordCount;

    [Header("UI References")]
    public GameObject doneCanvas;
    public GameObject removeCanvas;
    public GameObject LGBTQcircle;
    public GameObject LGBTQwords;
    public GameObject LGBTQwoods;

    [Header("Coin Rewards")]
    public CoinsValue coins;
    public int coinReward;
    public TrackCoins coinsDB;

    [Header("Animation")]
    public Animator animator; // ✅ Drag your character or UI Animator here in Inspector

    // ✅ Bool getter (true if not yet complete)
    public bool IsBelowWordCount => counter < wordCount;

    public void counterCheck()
    {
        counter++;
        Debug.Log($"🧮 WordCounter → Progress: {counter}/{wordCount}");

        if (counter >= wordCount)
        {
            if (removeCanvas != null)
                removeCanvas.SetActive(false);

            Debug.Log("✅ WORD PUZZLE DONE!");
            LGBTQwords.SetActive(false);
            LGBTQwoods.SetActive(true);
            // ✅ Trigger "Happy" animation if assigned
            if (animator != null)
            {
                animator.SetTrigger("Happy");
                Debug.Log("🎉 Triggered animation: Happy");
            }
            else
            {
                Debug.LogWarning("⚠️ No Animator assigned — 'Happy' trigger skipped.");
            }

            if (LGBTQcircle != null)
                LGBTQcircle.SetActive(false);

            // ✅ Add coins
            coins?.IncrementScore(coinReward);
            coinsDB?.IncrementScore(coinReward);

            if (doneCanvas != null)
                doneCanvas.SetActive(true);
        }
    }
}
