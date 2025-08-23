using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class CoinsValue : MonoBehaviour
{
    public static CoinsValue Instance { get; private set; }
    private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText; // Reference to the TextMeshPro UI

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreText();
    }

    public void IncrementScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    public void DecrementScore(int amount)
    {
        score -= amount;
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