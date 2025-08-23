using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class CoinsValue : MonoBehaviour
{
    public static CoinsValue Instance { get; private set; }
    private int score; // will be set from PlayerPrefs
    [SerializeField] private TextMeshProUGUI scoreText; // Reference to the TextMeshPro UI

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // 🔥 Load saved score immediately when object is created
            score = PlayerPrefs.GetInt("coins", 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreText(); // update UI with loaded coins
    }

    public void IncrementScore(int amount)
    {
        score += amount;
        SaveScore();
    }

    public void ResetScore()
    {
        score = 0;
        SaveScore();
    }

    public void DecrementScore(int amount)
    {
        score -= amount;
        if (score < 0) score = 0; // prevent negative coins
        SaveScore();
    }

    private void SaveScore()
    {
        PlayerPrefs.SetInt("coins", score);
        PlayerPrefs.Save();
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }

    // Getter function to retrieve the current score
    public int GetScore()
    {
        return score;
    }
}
