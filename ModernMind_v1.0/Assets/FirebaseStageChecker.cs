using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System;

public class FirebaseStageChecker : MonoBehaviour
{
    private DatabaseReference dbReference;

    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Result == DependencyStatus.Available)
            {
                string databaseUrl = "https://modernmind-142ff-default-rtdb.firebaseio.com/";
                FirebaseDatabase database = FirebaseDatabase.GetInstance(FirebaseApp.DefaultInstance, databaseUrl);
                dbReference = database.RootReference;

                // ✅ Get saved username from login
                string username = PlayerPrefs.GetString("normalizedUsername", "");
                if (!string.IsNullOrEmpty(username))
                {
                    LoadUserStages(username);
                }
                else
                {
                    Debug.LogWarning("[FirebaseStageChecker] No username found in PlayerPrefs.");
                }
            }
            else
            {
                Debug.LogError("[FirebaseStageChecker] Could not resolve Firebase dependencies: " + task.Result);
            }
        });
    }

    void LoadUserStages(string username)
    {
        dbReference.Child("users").Child(username).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCompletedSuccessfully && task.Result.Exists)
            {
                string json = task.Result.GetRawJsonValue();
                UserData userData = JsonUtility.FromJson<UserData>(json);

                CheckStages(userData);
            }
            else
            {
                Debug.LogError("[FirebaseStageChecker] Failed to load user data.");
            }
        });
    }

    void CheckStages(UserData userData)
    {
        // ✅ Level 1
        if (userData.levels.level1.stage1)
            Debug.Log("Stage 1 Level 1 UNLOCKED");
        else
            Debug.Log("Stage 1 Level 1 LOCKED");

        if (userData.levels.level1.stage2)
            Debug.Log("Stage 2 Level 1 UNLOCKED");
        else
            Debug.Log("Stage 2 Level 1 LOCKED");

        if (userData.levels.level1.stage3)
            Debug.Log("Stage 3 Level 1 UNLOCKED");
        else
            Debug.Log("Stage 3 Level 1 LOCKED");

        // ✅ Level 2
        if (userData.levels.level2.stage1)
            Debug.Log("Stage 1 Level 2 UNLOCKED");
        else
            Debug.Log("Stage 1 Level 2 LOCKED");

        if (userData.levels.level2.stage2)
            Debug.Log("Stage 2 Level 2 UNLOCKED");
        else
            Debug.Log("Stage 2 Level 2 LOCKED");

        if (userData.levels.level2.stage3)
            Debug.Log("Stage 3 Level 2 UNLOCKED");
        else
            Debug.Log("Stage 3 Level 2 LOCKED");

        // ✅ Level 3
        if (userData.levels.level3.stage1)
            Debug.Log("Stage 1 Level 3 UNLOCKED");
        else
            Debug.Log("Stage 1 Level 3 LOCKED");

        if (userData.levels.level3.stage2)
            Debug.Log("Stage 2 Level 3 UNLOCKED");
        else
            Debug.Log("Stage 2 Level 3 LOCKED");

        if (userData.levels.level3.stage3)
            Debug.Log("Stage 3 Level 3 UNLOCKED");
        else
            Debug.Log("Stage 3 Level 3 LOCKED");
    }
}
