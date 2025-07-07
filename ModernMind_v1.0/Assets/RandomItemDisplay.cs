using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System;

public class FirebaseItemTest : MonoBehaviour
{
    private DatabaseReference dbReference;

    void Start()
    {
        Debug.Log("[FirebaseItemTest] Checking Firebase dependencies...");

        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted && task.Result == DependencyStatus.Available)
            {
                Debug.Log("[FirebaseItemTest] Firebase is ready.");

                try
                {
                    string databaseUrl = "https://modernmind-142ff-default-rtdb.firebaseio.com/";
                    FirebaseDatabase database = FirebaseDatabase.GetInstance(FirebaseApp.DefaultInstance, databaseUrl);
                    dbReference = database.RootReference;

                    Debug.Log("[FirebaseItemTest] Got DB reference. Now reading items...");
                    ReadItems();
                }
                catch (Exception e)
                {
                    Debug.LogError("[FirebaseItemTest] Exception setting up database: " + e);
                }
            }
            else
            {
                Debug.LogError("[FirebaseItemTest] Firebase not available: " + task.Exception);
            }
        });
    }

    void ReadItems()
    {
        dbReference.Child("items").GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("[FirebaseItemTest] Error reading items: " + task.Exception);
                return;
            }

            if (task.IsCompletedSuccessfully)
            {
                DataSnapshot snapshot = task.Result;

                if (!snapshot.Exists || !snapshot.HasChildren)
                {
                    Debug.LogWarning("[FirebaseItemTest] No items found.");
                    return;
                }

                Debug.Log("[FirebaseItemTest] Items found: " + snapshot.ChildrenCount);

                foreach (DataSnapshot item in snapshot.Children)
                {
                    string key = item.Key;
                    string title = item.Child("title").Value?.ToString();
                    string description = item.Child("description").Value?.ToString();
                    string image = item.Child("image").Value?.ToString();

                    Debug.Log($"[FirebaseItemTest] Item Key: {key}");
                    Debug.Log($"  Title: {title}");
                    Debug.Log($"  Description: {description}");
                    Debug.Log($"  Image: {image}");
                }
            }
        });
    }
}
