using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;

public class UsernameLogin : MonoBehaviour
{
    public InputField usernameInputField;

    private DatabaseReference dbReference;

    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
            FirebaseApp app = FirebaseApp.DefaultInstance;
            dbReference = FirebaseDatabase.DefaultInstance.RootReference;
            Debug.Log("Firebase initialized.");
        });
    }

    public void OnLoginButtonClicked()
    {
        string username = usernameInputField.text.Trim();

        if (string.IsNullOrEmpty(username))
        {
            Debug.Log("Username is empty.");
            return;
        }

        CheckIfUserExists(username);
    }

    void CheckIfUserExists(string username)
    {
        dbReference.Child("users").Child(username).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                Debug.Log("Error checking username.");
            }
            else if (task.Result.Exists)
            {
                Debug.Log("User exists. Loading user data...");
                ProceedToScene1();
            }
            else
            {
                Debug.Log("New user. Creating profile...");
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
            if (task.IsCompleted)
            {
                Debug.Log("New user saved to Firebase.");
                ProceedToScene1();
            }
            else
            {
                Debug.Log("Failed to save new user.");
            }
        });
    }

    void ProceedToScene1()
    {
        Debug.Log("Loading Scene1...");
        SceneManager.LoadScene("Scene1");
    }
}

[System.Serializable]
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
