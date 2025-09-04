using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System;

public class FirebaseStageChecker : MonoBehaviour
{
    private DatabaseReference dbReference;

    // ✅ GameObjects for lock/unlock UI
    public GameObject yunit1Lock, yunit1Unlock, yunit2Lock, yunit2Unlock, yunit3Lock, yunit3Unlock, yunit4Lock, yunit4Unlock;
    public GameObject yunit1Stage1Lock, yunit1Stage1Unlock, yunit1Stage2Lock, yunit1Stage2Unlock, yunit1Stage3Lock, yunit1Stage3Unlock;
    public GameObject yunit2Stage1Lock, yunit2Stage1Unlock, yunit2Stage2Lock, yunit2Stage2Unlock, yunit2Stage3Lock, yunit2Stage3Unlock;
    public GameObject yunit3Stage1Lock, yunit3Stage1Unlock, yunit3Stage2Lock, yunit3Stage2Unlock, yunit3Stage3Lock, yunit3Stage3Unlock;
    public GameObject yunit4Stage1Lock, yunit4Stage1Unlock, yunit4Stage2Lock, yunit4Stage2Unlock, yunit4Stage3Lock, yunit4Stage3Unlock;

    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Result == DependencyStatus.Available)
            {
                string databaseUrl = "https://modernmind-142ff-default-rtdb.firebaseio.com/";
                FirebaseDatabase database = FirebaseDatabase.GetInstance(FirebaseApp.DefaultInstance, databaseUrl);
                dbReference = database.RootReference;

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
        if (userData.levels.level1.unlocked)
        {
            yunit1Lock.SetActive(false);
            yunit1Unlock.SetActive(true);
        }
        else
        {
            yunit1Lock.SetActive(true);
            yunit1Unlock.SetActive(false);
        }

        if (userData.levels.level1.stage1)
        {
            yunit1Stage1Lock.SetActive(false);
            yunit1Stage1Unlock.SetActive(true);
        }
        else
        {
            yunit1Stage1Lock.SetActive(true);
            yunit1Stage1Unlock.SetActive(false);
        }

        if (userData.levels.level1.stage2)
        {
            yunit1Stage2Lock.SetActive(false);
            yunit1Stage2Unlock.SetActive(true);
        }
        else
        {
            yunit1Stage2Lock.SetActive(true);
            yunit1Stage2Unlock.SetActive(false);
        }

        if (userData.levels.level1.stage3)
        {
            yunit1Stage3Lock.SetActive(false);
            yunit1Stage3Unlock.SetActive(true);
        }
        else
        {
            yunit1Stage3Lock.SetActive(true);
            yunit1Stage3Unlock.SetActive(false);
        }

        // ✅ Level 2
        if (userData.levels.level2.unlocked)
        {
            yunit2Lock.SetActive(false);
            yunit2Unlock.SetActive(true);
        }
        else
        {
            yunit2Lock.SetActive(true);
            yunit2Unlock.SetActive(false);
        }

        if (userData.levels.level2.stage1)
        {
            yunit2Stage1Lock.SetActive(false);
            yunit2Stage1Unlock.SetActive(true);
        }
        else
        {
            yunit2Stage1Lock.SetActive(true);
            yunit2Stage1Unlock.SetActive(false);
        }

        if (userData.levels.level2.stage2)
        {
            yunit2Stage2Lock.SetActive(false);
            yunit2Stage2Unlock.SetActive(true);
        }
        else
        {
            yunit2Stage2Lock.SetActive(true);
            yunit2Stage2Unlock.SetActive(false);
        }

        if (userData.levels.level2.stage3)
        {
            yunit2Stage3Lock.SetActive(false);
            yunit2Stage3Unlock.SetActive(true);
        }
        else
        {
            yunit2Stage3Lock.SetActive(true);
            yunit2Stage3Unlock.SetActive(false);
        }

        // ✅ Level 3
        if (userData.levels.level3.unlocked)
        {
            yunit3Lock.SetActive(false);
            yunit3Unlock.SetActive(true);
        }
        else
        {
            yunit3Lock.SetActive(true);
            yunit3Unlock.SetActive(false);
        }

        if (userData.levels.level3.stage1)
        {
            yunit3Stage1Lock.SetActive(false);
            yunit3Stage1Unlock.SetActive(true);
        }
        else
        {
            yunit3Stage1Lock.SetActive(true);
            yunit3Stage1Unlock.SetActive(false);
        }

        if (userData.levels.level3.stage2)
        {
            yunit3Stage2Lock.SetActive(false);
            yunit3Stage2Unlock.SetActive(true);
        }
        else
        {
            yunit3Stage2Lock.SetActive(true);
            yunit3Stage2Unlock.SetActive(false);
        }

        if (userData.levels.level3.stage3)
        {
            yunit3Stage3Lock.SetActive(false);
            yunit3Stage3Unlock.SetActive(true);
        }
        else
        {
            yunit3Stage3Lock.SetActive(true);
            yunit3Stage3Unlock.SetActive(false);
        }

        // ✅ Level 4 placeholder (if you add it later)
        if (userData.levels.level4 != null && userData.levels.level4.unlocked)
        {
            yunit4Lock.SetActive(false);
            yunit4Unlock.SetActive(true);
        }
        else
        {
            yunit4Lock.SetActive(true);
            yunit4Unlock.SetActive(false);
        }
    }
}
