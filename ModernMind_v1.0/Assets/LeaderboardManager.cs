using UnityEngine;
using TMPro;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System.Collections.Generic;

public class LeaderboardManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI[] nameTexts;   // drag 5 name TMPs
    [SerializeField] private TextMeshProUGUI[] scoreTexts;  // drag 5 score TMPs

    private DatabaseReference dbReference;
    private bool isReady = false;

    private void Start()
    {
        // Init Firebase
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Result == DependencyStatus.Available)
            {
                string databaseUrl = "https://modernmind-142ff-default-rtdb.firebaseio.com/";
                FirebaseDatabase database = FirebaseDatabase.GetInstance(FirebaseApp.DefaultInstance, databaseUrl);
                dbReference = database.RootReference;
                isReady = true;

                RefreshLeaderboard(); // auto-load once
            }
            else
            {
                Debug.LogError("[LeaderboardManager] Firebase dependencies not resolved.");
            }
        });
    }

    // ✅ Call this to refresh leaderboard anytime
    public void RefreshLeaderboard()
    {
        if (!isReady)
        {
            Debug.LogWarning("[LeaderboardManager] Firebase not ready yet.");
            return;
        }

        dbReference.Child("users")
            .OrderByChild("score")
            .LimitToLast(15) // top 5 highest scores
            .GetValueAsync()
            .ContinueWithOnMainThread(task =>
            {
                if (task.IsFaulted)
                {
                    Debug.LogError("[LeaderboardManager] Failed to load leaderboard: " + task.Exception);
                    return;
                }

                if (task.IsCompletedSuccessfully)
                {
                    DataSnapshot snapshot = task.Result;
                    List<(string name, int score)> leaderboard = new List<(string, int)>();

                    foreach (DataSnapshot child in snapshot.Children)
                    {
                        string username = child.Key;
                        int score = 0;
                        if (child.Child("score").Exists)
                        {
                            int.TryParse(child.Child("score").Value.ToString(), out score);
                        }
                        leaderboard.Add((username, score));
                    }

                    // sort descending (highest first)
                    leaderboard.Sort((a, b) => b.score.CompareTo(a.score));

                    // fill UI
                    for (int i = 0; i < nameTexts.Length; i++)
                    {
                        if (i < leaderboard.Count)
                        {
                            nameTexts[i].text = leaderboard[i].name;
                            scoreTexts[i].text = leaderboard[i].score.ToString();
                        }
                        else
                        {
                            nameTexts[i].text = "-";
                            scoreTexts[i].text = "0";
                        }
                    }

                    Debug.Log("[LeaderboardManager] Leaderboard refreshed.");
                }
            });
    }
}
