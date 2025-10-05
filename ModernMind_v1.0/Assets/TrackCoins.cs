using UnityEngine;

public class TrackCoins : MonoBehaviour
{
    public string coinsKey = "Coins";
    private int score;

    private void Start()
    {
        score = PlayerPrefs.GetInt(coinsKey, 0);
    }

    public void IncrementScore(int amount)
    {
        score += amount;
        PlayerPrefs.SetInt(coinsKey, score);
        PlayerPrefs.Save();
    }

    public int GetScore()
    {
        return score;
    }

    public void SetScore(int value)
    {
        score = value;
        PlayerPrefs.SetInt(coinsKey, score);
        PlayerPrefs.Save();
    }
}
