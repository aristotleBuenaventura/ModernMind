using UnityEngine;
using TMPro;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System;

public class DisplayUsernameUI : MonoBehaviour
{
    public TextMeshProUGUI usernameText; 
    private DatabaseReference dbReference;
    private string normalizedUsername;

    void Start()
    {
        normalizedUsername = PlayerPrefs.GetString("normalizedUsername", "");

        if (string.IsNullOrEmpty(normalizedUsername))
        {
            usernameText.text = "No user logged in.";
            return;
        }

        InitializeFirebase();
    }

    void InitializeFirebase()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Result == DependencyStatus.Available)
            {
                string databaseUrl = "https://modernmind-142ff-default-rtdb.firebaseio.com/";
                FirebaseDatabase database = FirebaseDatabase.GetInstance(FirebaseApp.DefaultInstance, databaseUrl);
                dbReference = database.RootReference;

                LoadUsername();
            }
            else
            {
                usernameText.text = "Firebase not ready.";
            }
        });
    }

    void LoadUsername()
    {
        dbReference.Child("users").Child(normalizedUsername).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCompletedSuccessfully && task.Result.Exists)
            {
                string displayName = task.Result.Child("username").Value.ToString();
                usernameText.text = displayName.ToUpper();
            }
            else
            {
                usernameText.text = "User not found.";
            }
        });
    }
}
