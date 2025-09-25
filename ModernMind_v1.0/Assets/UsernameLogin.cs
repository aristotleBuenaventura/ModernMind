using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System;

public class FirebaseLogin : MonoBehaviour
{
    [Header("UI References")]
    public TMP_InputField usernameInput;
    public Button loginButton;
    public GameObject mainmenu, selection, bagonglaro;
    public FirebaseStageChecker checker;

    private DatabaseReference dbReference;

    void Start()
    {
        loginButton.interactable = false;  // Disable button until Firebase is ready

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
                    Debug.LogError("[FirebaseLogin] Exception getting DB reference: " + e);
                }

                loginButton.interactable = true;  // Enable button now that Firebase is ready
            }
            else
            {
                Debug.LogError("[FirebaseLogin] Could not resolve Firebase dependencies: " + task.Result);
            }
        });
    }

    // Called by the button OnClick
    public void OnLoginClicked()
    {
        if (dbReference == null)
        {
            Debug.LogError("[FirebaseLogin] Database reference is not ready.");
            return;
        }

        string inputUsername = usernameInput.text.Trim();

        if (string.IsNullOrEmpty(inputUsername))
        {
            Debug.LogWarning("[FirebaseLogin] Username input is empty.");
            return;
        }

        string normalizedUsername = inputUsername.ToLower();
        CheckIfUserExists(normalizedUsername, inputUsername);
    }

    void CheckIfUserExists(string normalizedUsername, string originalUsername)
    {
        Debug.Log($"[FirebaseLogin] Checking if username '{normalizedUsername}' exists...");

        dbReference.Child("users").Child(normalizedUsername).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("[FirebaseLogin] Error checking user: " + task.Exception);
            }
            else if (task.Result.Exists)
            {
                Debug.Log("[FirebaseLogin] User exists. Loading progress...");

                PlayerPrefs.SetString("normalizedUsername", normalizedUsername);
                PlayerPrefs.Save();

                LoadUserProgress(normalizedUsername);
                ProceedToMenu();
            }
            else
            {
                Debug.Log("[FirebaseLogin] New user detected. Creating user...");
                SaveNewUser(normalizedUsername, originalUsername);
            }
        });
    }

    void SaveNewUser(string normalizedUsername, string originalUsername)
    {
        UserData newUser = new UserData(originalUsername);
        string json = JsonUtility.ToJson(newUser);

        dbReference.Child("users").Child(normalizedUsername).SetRawJsonValueAsync(json).ContinueWithOnMainThread(task =>
        {
            if (task.IsCompletedSuccessfully)
            {
                Debug.Log("[FirebaseLogin] New user saved. Proceeding to menu...");

                PlayerPrefs.SetString("normalizedUsername", normalizedUsername);
                PlayerPrefs.Save();

                ProceedToMenu();
            }
            else
            {
                Debug.LogError("[FirebaseLogin] Failed to save new user: " + task.Exception);
            }
        });
    }

    void ProceedToMenu()
    {
        checker.StartManual();
        mainmenu.SetActive(false);
        bagonglaro.SetActive(false);
        selection.SetActive(true);
    }

    void LoadUserProgress(string normalizedUsername)
    {
        dbReference.Child("users").Child(normalizedUsername).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCompletedSuccessfully && task.Result.Exists)
            {
                string json = task.Result.GetRawJsonValue();
                UserData userData = JsonUtility.FromJson<UserData>(json);

                Debug.Log("[FirebaseLogin] User progress loaded:");
                Debug.Log(JsonUtility.ToJson(userData, true));
            }
        });
    }
}

[Serializable]
public class UserData
{
    public string username;
    public int score = 0;
    public Levels levels;

    public UserData(string username)
    {
        this.username = username;
        this.score = 0;
        this.levels = new Levels();
    }
}

[Serializable]
public class Levels
{
    public Level level1 = new Level(true, true);
    public Level level2 = new Level(false, false);
    public Level level3 = new Level(false, false);
    public Level level4 = new Level(false, false);
}

[Serializable]
public class Level
{
    public bool unlocked;
    public bool stage1;
    public bool stage2;
    public bool stage3;

    public Level()
    {
        unlocked = false;
        stage1 = false;
        stage2 = false;
        stage3 = false;
    }

    public Level(bool levelUnlocked, bool unlockStage1)
    {
        unlocked = levelUnlocked;
        stage1 = unlockStage1;
        stage2 = false;
        stage3 = false;
    }
}
