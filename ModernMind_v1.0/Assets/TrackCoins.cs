using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class TrackCoins : MonoBehaviour
{
    private int score;

    public void IncrementScore(int amount)
    {
        score += amount;

    }
    // Getter function to retrieve the current score
    public int GetScore()
    {
        return score;
    }
}
