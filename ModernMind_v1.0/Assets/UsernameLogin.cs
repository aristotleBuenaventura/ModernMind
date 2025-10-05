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
        loginButton.interactable = false;

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

                loginButton.interactable = true;
            }
            else
            {
                Debug.LogError("[FirebaseLogin] Could not resolve Firebase dependencies: " + task.Result);
            }
        });
    }

    public void OnLoginClicked()
    {
        if (dbReference == null) return;

        string inputUsername = usernameInput.text.Trim();
        if (string.IsNullOrEmpty(inputUsername)) return;

        string normalizedUsername = inputUsername.ToLower();
        CheckIfUserExists(normalizedUsername, inputUsername);
    }

    void CheckIfUserExists(string normalizedUsername, string originalUsername)
    {
        dbReference.Child("users").Child(normalizedUsername).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("[FirebaseLogin] Error checking user: " + task.Exception);
            }
            else if (task.Result.Exists)
            {
                PlayerPrefs.SetString("normalizedUsername", normalizedUsername);
                PlayerPrefs.Save();

                LoadUserProgress(normalizedUsername);
                ProceedToMenu();
            }
            else
            {
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
    public int stage1Coins;

    public bool stage2;
    public int stage2Coins;

    public bool stage3;
    public int stage3Coins;

    public Level()
    {
        unlocked = false;
        stage1 = false;
        stage1Coins = 0;
        stage2 = false;
        stage2Coins = 0;
        stage3 = false;
        stage3Coins = 0;
    }

    public Level(bool levelUnlocked, bool unlockStage1)
    {
        unlocked = levelUnlocked;
        stage1 = unlockStage1;
        stage1Coins = 0;
        stage2 = false;
        stage2Coins = 0;
        stage3 = false;
        stage3Coins = 0;
    }
}
