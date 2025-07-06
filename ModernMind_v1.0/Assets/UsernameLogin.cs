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
        Debug.Log("[FirebaseLogin] Start() called. Initializing Firebase...");

        loginButton.interactable = false;  // Disable button until Firebase is ready

        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Result == DependencyStatus.Available)
            {
                Debug.Log("[FirebaseLogin] Firebase dependencies are available.");

                try
                {
                    string databaseUrl = "https://modernmind-142ff-default-rtdb.firebaseio.com/";
                    FirebaseDatabase database = FirebaseDatabase.GetInstance(FirebaseApp.DefaultInstance, databaseUrl);
                    dbReference = database.RootReference;
                    Debug.Log("[FirebaseLogin] Got database reference: " + (dbReference != null));
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

        string username = usernameInput.text.Trim();

        if (string.IsNullOrEmpty(username))
        {
            Debug.LogWarning("[FirebaseLogin] Username input is empty.");
            return;
        }

        CheckIfUserExists(username);
    }

    void CheckIfUserExists(string username)
    {
        Debug.Log($"[FirebaseLogin] Checking if username '{username}' exists...");

        dbReference.Child("users").Child(username).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("[FirebaseLogin] Error checking user: " + task.Exception);
            }
            else if (task.Result.Exists)
            {
                Debug.Log("[FirebaseLogin] User exists. Proceeding to Scene1...");
                ProceedToScene1();
            }
            else
            {
                Debug.Log("[FirebaseLogin] New user detected. Creating user...");
                SaveNewUser(username);
            }
        });
    }

    void SaveNewUser(string username)
    {
        UserData newUser = new UserData(username);
        string json = JsonUtility.ToJson(newUser);

        dbReference.Child("users").Child(username).SetRawJsonValueAsync(json).ContinueWithOnMainThread(task =>
        {
            if (task.IsCompletedSuccessfully)
            {
                Debug.Log("[FirebaseLogin] New user saved. Proceeding to Scene1...");
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
        Debug.Log("[FirebaseLogin] Loading Scene1...");
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
