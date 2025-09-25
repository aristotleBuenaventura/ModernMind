using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ContinueGameWithStages : MonoBehaviour
{
    private DatabaseReference dbReference;
    private string username;
    private bool isReady = false;

    private Dictionary<string, string> stageSceneMap = new Dictionary<string, string>()
    {
        { "level1_stage1", "Scene1" },
        { "level1_stage2", "Scene1_Hopscotch" },
        { "level1_stage3", "Scene1_Search" },

        { "level2_stage1", "Scene2" },
        { "level2_stage2", "Scene2_Hopscotch" },
        { "level2_stage3", "Gabay" },

        { "level3_stage1", "Gabay" },
        { "level3_stage2", "Gabay" },
        { "level3_stage3", "Gabay" },

        { "level4_stage1", "Gabay" },
        { "level4_stage2", "Gabay" },
        { "level4_stage3", "Gabay" }
    };

    private void Start()
    {
        username = PlayerPrefs.GetString("normalizedUsername", "");
        Debug.Log("[ContinueGame] 🔎 Loaded username from PlayerPrefs: '" + username + "'");

        if (string.IsNullOrEmpty(username))
        {
            Debug.LogError("[ContinueGame] ❌ No username found in PlayerPrefs. Did you login?");
            return;
        }

        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Result == DependencyStatus.Available)
            {
                string databaseUrl = "https://modernmind-142ff-default-rtdb.firebaseio.com/";
                FirebaseDatabase database = FirebaseDatabase.GetInstance(FirebaseApp.DefaultInstance, databaseUrl);
                dbReference = database.RootReference;
                isReady = true;
                Debug.Log("[ContinueGame] ✅ Firebase initialized for user: " + username);

                CheckFarthestStageOnly();
            }
            else
            {
                Debug.LogError("[ContinueGame] ❌ Firebase dependencies not resolved.");
            }
        });
    }

    private void CheckFarthestStageOnly()
    {
        dbReference.Child("users").Child(username).Child("levels").GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted || !task.IsCompletedSuccessfully)
            {
                Debug.LogError("[ContinueGame] ❌ Failed to check levels: " + task.Exception);
                return;
            }

            DataSnapshot snapshot = task.Result;
            string farthestLevel = null;
            string farthestStage = null;

            List<string> unlockedLevels = new List<string>();
            foreach (DataSnapshot levelSnapshot in snapshot.Children)
            {
                string levelName = levelSnapshot.Key;

                if (levelSnapshot.Child("unlocked").Exists &&
                    bool.TryParse(levelSnapshot.Child("unlocked").Value.ToString(), out bool unlocked) &&
                    unlocked)
                {
                    unlockedLevels.Add(levelName);
                }
            }

            unlockedLevels.Sort((a, b) =>
            {
                int aNum = int.Parse(a.Replace("level", ""));
                int bNum = int.Parse(b.Replace("level", ""));
                return aNum.CompareTo(bNum);
            });

            if (unlockedLevels.Count > 0)
            {
                farthestLevel = unlockedLevels[unlockedLevels.Count - 1];
                DataSnapshot lastLevelSnapshot = snapshot.Child(farthestLevel);

                List<string> unlockedStages = new List<string>();
                foreach (DataSnapshot stageSnapshot in lastLevelSnapshot.Children)
                {
                    string stageName = stageSnapshot.Key;
                    if (stageName.StartsWith("stage") &&
                        bool.TryParse(stageSnapshot.Value.ToString(), out bool stageValue) &&
                        stageValue)
                    {
                        unlockedStages.Add(stageName);
                    }
                }

                unlockedStages.Sort((a, b) =>
                {
                    int aNum = int.Parse(a.Replace("stage", ""));
                    int bNum = int.Parse(b.Replace("stage", ""));
                    return aNum.CompareTo(bNum);
                });

                if (unlockedStages.Count > 0)
                {
                    farthestStage = unlockedStages[unlockedStages.Count - 1];
                    string key = farthestLevel + "_" + farthestStage;

                    Debug.Log($"[ContinueGame] 👤 User: {username} | 🎯 Last unlocked: {farthestLevel} - {farthestStage}");

                    if (stageSceneMap.ContainsKey(key))
                        Debug.Log("[ContinueGame] 🔎 Scene mapping found: " + stageSceneMap[key]);
                    else
                        Debug.LogWarning("[ContinueGame] ⚠️ No mapping found for " + key);
                }
                else
                {
                    Debug.LogWarning("[ContinueGame] ⚠️ No unlocked stages in " + farthestLevel);
                }
            }
            else
            {
                Debug.LogWarning("[ContinueGame] ⚠️ No unlocked levels for " + username);
            }
        });
    }

    public void ContinueToLastStage()
    {
        if (!isReady)
        {
            Debug.LogWarning("[ContinueGame] ⚠️ Firebase not ready yet.");
            return;
        }

        dbReference.Child("users").Child(username).Child("levels").GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("[ContinueGame] ❌ Failed to load levels: " + task.Exception);
                return;
            }

            if (task.IsCompletedSuccessfully)
            {
                DataSnapshot snapshot = task.Result;
                string farthestLevel = null;
                string farthestStage = null;

                List<string> unlockedLevels = new List<string>();
                foreach (DataSnapshot levelSnapshot in snapshot.Children)
                {
                    string levelName = levelSnapshot.Key;

                    if (levelSnapshot.Child("unlocked").Exists &&
                        bool.TryParse(levelSnapshot.Child("unlocked").Value.ToString(), out bool unlocked) &&
                        unlocked)
                    {
                        unlockedLevels.Add(levelName);
                    }
                }

                unlockedLevels.Sort((a, b) =>
                {
                    int aNum = int.Parse(a.Replace("level", ""));
                    int bNum = int.Parse(b.Replace("level", ""));
                    return aNum.CompareTo(bNum);
                });

                if (unlockedLevels.Count > 0)
                {
                    farthestLevel = unlockedLevels[unlockedLevels.Count - 1];
                    DataSnapshot lastLevelSnapshot = snapshot.Child(farthestLevel);

                    List<string> unlockedStages = new List<string>();
                    foreach (DataSnapshot stageSnapshot in lastLevelSnapshot.Children)
                    {
                        string stageName = stageSnapshot.Key;
                        if (stageName.StartsWith("stage") &&
                            bool.TryParse(stageSnapshot.Value.ToString(), out bool stageValue) &&
                            stageValue)
                        {
                            unlockedStages.Add(stageName);
                        }
                    }

                    unlockedStages.Sort((a, b) =>
                    {
                        int aNum = int.Parse(a.Replace("stage", ""));
                        int bNum = int.Parse(b.Replace("stage", ""));
                        return aNum.CompareTo(bNum);
                    });

                    if (unlockedStages.Count > 0)
                    {
                        farthestStage = unlockedStages[unlockedStages.Count - 1];
                        string key = farthestLevel + "_" + farthestStage;

                        Debug.Log($"[ContinueGame] 👤 User: {username} | 🎯 Continuing at: {farthestLevel} - {farthestStage}");

                        if (stageSceneMap.ContainsKey(key))
                        {
                            string sceneToLoad = stageSceneMap[key];
                            Debug.Log("[ContinueGame] ▶️ Loading scene: " + sceneToLoad);
                            SceneManager.LoadScene(sceneToLoad);
                        }
                        else
                        {
                            Debug.LogWarning("[ContinueGame] ⚠️ No mapping found for " + key + ", loading default scene.");
                            SceneManager.LoadScene("Default_Scene");
                        }
                    }
                    else
                    {
                        Debug.LogWarning("[ContinueGame] ⚠️ No unlocked stages in " + farthestLevel);
                        SceneManager.LoadScene("Gabay");
                    }
                }
                else
                {
                    Debug.LogWarning("[ContinueGame] ⚠️ No unlocked levels, starting from Level1 Stage1.");
                    SceneManager.LoadScene("Scene1");
                }
            }
        });
    }
}
