using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System;

public class FirebaseLogin : MonoBehaviour
{
    [Header("UI References")]
    public TMP_InputField usernameInput;
    public Button loginButton;

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

        string normalizedUsername = inputUsername.ToLower(); // Normalize for case-insensitive
        CheckIfUserExists(normalizedUsername, inputUsername); // Pass both normalized and original
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
                Debug.Log("[FirebaseLogin] User exists. Proceeding to Scene1...");

                // ✅ Save the username before loading the next scene
                PlayerPrefs.SetString("normalizedUsername", normalizedUsername);
                PlayerPrefs.Save();

                ProceedToScene1();
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
        UserData newUser = new UserData(originalUsername);  // Save original casing for display
        string json = JsonUtility.ToJson(newUser);

        dbReference.Child("users").Child(normalizedUsername).SetRawJsonValueAsync(json).ContinueWithOnMainThread(task =>
        {
            if (task.IsCompletedSuccessfully)
            {
                Debug.Log("[FirebaseLogin] New user saved. Proceeding to Scene1...");

                // ✅ Save the username before loading the next scene
                PlayerPrefs.SetString("normalizedUsername", normalizedUsername);
                PlayerPrefs.Save();

                ProceedToScene1();
            }
            else
            {
                Debug.LogError("[FirebaseLogin] Failed to save new user: " + task.Exception);
            }
        });
    }

    void ProceedToScene1()
    {
        SceneManager.LoadScene("Scene1");
    }
}

[Serializable]
public class UserData
{
    public string username;
    public int score = 0;
    public int level = 1;

    public UserData(string username)
    {
        this.username = username;
    }
}
