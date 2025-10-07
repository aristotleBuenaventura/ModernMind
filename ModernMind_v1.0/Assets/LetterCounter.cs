using UnityEngine;

public class LetterCounter : MonoBehaviour
{
    private int counter;
    public int wordCount;
    public GameObject doneCanvas, removeCanvas;
    public CoinsValue coins;
    public int coinReward;
    public TrackCoins coinsDB;

    // ✅ Bool getter (true if not yet complete)
    public bool IsBelowWordCount => counter < wordCount;

    public void counterCheck()
    {
        counter++;
        Debug.Log("counter: " + counter);

        if (counter >= wordCount)
        {
            if (removeCanvas != null) removeCanvas.SetActive(false);
            Debug.Log("LETTER DONE");
            coins.IncrementScore(coinReward);
            coinsDB.IncrementScore(coinReward);
            if (doneCanvas != null) doneCanvas.SetActive(true);
        }
    }
}
