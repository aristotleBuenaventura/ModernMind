using UnityEngine;
using TMPro;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;

public class CoinsValue : MonoBehaviour
{
    public static CoinsValue Instance { get; private set; }
    private int score;
    [SerializeField] private TextMeshProUGUI scoreText;

    private DatabaseReference dbReference;
    private string username;
    private bool isReady = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Load coins from PlayerPrefs
            score = PlayerPrefs.GetInt("coins", 0);

            // Get username from PlayerPrefs
            username = PlayerPrefs.GetString("normalizedUsername", "");
            if (string.IsNullOrEmpty(username))
            {
                Debug.LogError("[CoinsValue] No username found in PlayerPrefs. Did you login?");
                return;
            }

            // Init Firebase
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
            {
                if (task.Result == DependencyStatus.Available)
                {
                    string databaseUrl = "https://modernmind-142ff-default-rtdb.firebaseio.com/";
                    FirebaseDatabase database = FirebaseDatabase.GetInstance(FirebaseApp.DefaultInstance, databaseUrl);
                    dbReference = database.RootReference;
                    isReady = true;
                    Debug.Log("[CoinsValue] Firebase initialized for user: " + username);

                    // ✅ Push current saved coins to Firebase
                    UpdateScoreInFirebase();
                }
                else
                {
                    Debug.LogError("[CoinsValue] Firebase dependencies not resolved.");
                }
            });
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
        if (score < 0) score = 0;
        SaveScore();
    }

    private void SaveScore()
    {
        PlayerPrefs.SetInt("coins", score);
        PlayerPrefs.Save();
        UpdateScoreText();
        UpdateScoreInFirebase();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }

    public int GetScore()
    {
        return score;
    }

    // ✅ Update username/score in Firebase
    private void UpdateScoreInFirebase()
    {
        if (!isReady || string.IsNullOrEmpty(username))
        {
            Debug.LogWarning("[CoinsValue] Firebase not ready yet. Score not updated.");
            return;
        }

        dbReference.Child("users")
        .Child(username)
        .Child("score")
        .SetValueAsync(score)
        .ContinueWithOnMainThread(task =>
        {
            if (task.IsCompletedSuccessfully)
            {
                Debug.Log("[CoinsValue] Firebase " + username + "/score updated to: " + score);
            }
            else
            {
                Debug.LogError("[CoinsValue] Failed to update score: " + task.Exception);
            }
        });
    }
}
