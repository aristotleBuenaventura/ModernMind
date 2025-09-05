using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System;

public class FirebaseStageUpdater : MonoBehaviour
{
    private DatabaseReference dbReference;
    private string username;
    private bool isReady = false; // 👈 new flag

    void Start()
    {
        // Get username from PlayerPrefs
        username = PlayerPrefs.GetString("normalizedUsername", "");
        if (string.IsNullOrEmpty(username))
        {
            Debug.LogError("[FirebaseStageUpdater] No username found in PlayerPrefs. Did you login?");
            return;
        }

        // Initialize Firebase
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Result == DependencyStatus.Available)
            {
                string databaseUrl = "https://modernmind-142ff-default-rtdb.firebaseio.com/";
                FirebaseDatabase database = FirebaseDatabase.GetInstance(FirebaseApp.DefaultInstance, databaseUrl);
                dbReference = database.RootReference;
                isReady = true; // 👈 Firebase is ready
                Debug.Log("[FirebaseStageUpdater] Firebase initialized for user: " + username);
            }
            else
            {
                Debug.LogError("[FirebaseStageUpdater] Firebase dependencies not resolved.");
            }
        });
    }

    // ✅ Update a specific stage
    public void UpdateStage(string levelName, string stageName, bool value)
    {
        if (!isReady)
        {
            Debug.LogWarning("[FirebaseStageUpdater] Firebase not ready yet. Try again later.");
            return;
        }

        dbReference.Child("users")
        .Child(username)
        .Child("levels")
        .Child(levelName)
        .Child(stageName)
        .SetValueAsync(value)
        .ContinueWithOnMainThread(task =>
        {
            if (task.IsCompletedSuccessfully)
            {
                Debug.Log($"[FirebaseStageUpdater] {levelName}/{stageName} updated to {value}");
            }
            else
            {
                Debug.LogError("[FirebaseStageUpdater] Failed to update stage: " + task.Exception);
            }
        });
    }

    // ✅ Update a whole level unlock status
    public void UpdateLevelUnlock(string levelName, bool value)
    {
        if (!isReady)
        {
            Debug.LogWarning("[FirebaseStageUpdater] Firebase not ready yet. Try again later.");

            return;
        }

        dbReference.Child("users")
        .Child(username)
        .Child("levels")
        .Child(levelName)
        .Child("unlocked")
        .SetValueAsync(value)
        .ContinueWithOnMainThread(task =>
        {
            if (task.IsCompletedSuccessfully)
            {
                Debug.Log($"[FirebaseStageUpdater] {levelName} unlocked = {value}");
            }
            else
            {
                Debug.LogError("[FirebaseStageUpdater] Failed to update level unlock: " + task.Exception);
            }
        });
    }
}