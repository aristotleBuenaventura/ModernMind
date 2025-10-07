using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System;

public class TrackCoins : MonoBehaviour
{
    public string levelNumber;
    public string stageNumber;
    private int coins;

    private DatabaseReference dbReference;

    private void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Result == DependencyStatus.Available)
            {
                try
                {
                    string databaseUrl = "https://modernmind-142ff-default-rtdb.firebaseio.com/";
                    FirebaseDatabase database = FirebaseDatabase.GetInstance(FirebaseApp.DefaultInstance, databaseUrl);
                    dbReference = database.RootReference;
                }
                catch (Exception e)
                {
                    Debug.LogError("[TrackCoins] Firebase init error: " + e);
                }
            }
            else
            {
                Debug.LogError("[TrackCoins] Firebase dependencies not available: " + task.Result);
            }
        });
    }

    public void IncrementScore(int amount)
    {
        coins += amount;
        SaveCoinsToDatabase(coins);
    }

    public int GetScore()
    {
        return coins;
    }

    public void SetScore(int value)
    {
        coins = value;
        SaveCoinsToDatabase(coins);
    }

    private void SaveCoinsToDatabase(int amount)
    {
        if (dbReference == null)
        {
            Debug.LogWarning("[TrackCoins] Database not ready yet.");
            return;
        }

        string normalizedUsername = PlayerPrefs.GetString("normalizedUsername", "");
        if (string.IsNullOrEmpty(normalizedUsername))
        {
            Debug.LogWarning("[TrackCoins] No username found in PlayerPrefs.");
            return;
        }

        string coinsPath = $"users/{normalizedUsername}/levels/{levelNumber}/stage{stageNumber}Coins";
        dbReference.Child(coinsPath).SetValueAsync(amount).ContinueWithOnMainThread(task =>
        {
            if (task.IsCompletedSuccessfully)
            {
                Debug.Log($"[TrackCoins] Saved {amount} coins to {coinsPath}");
            }
            else
            {
                Debug.LogError("[TrackCoins] Failed to save coins: " + task.Exception);
            }
        });
    }
}
