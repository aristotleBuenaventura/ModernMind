using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System;
using System.Collections.Generic;
using UnityEngine.Networking;
using System.Collections;

public class FirebaseRandomItemDisplay : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public Image itemImage;

    private DatabaseReference dbReference;

    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted && task.Result == DependencyStatus.Available)
            {
                string databaseUrl = "https://modernmind-142ff-default-rtdb.firebaseio.com/";
                FirebaseDatabase database = FirebaseDatabase.GetInstance(FirebaseApp.DefaultInstance, databaseUrl);
                dbReference = database.RootReference;

                LoadRandomItem();
            }
            else
            {
                Debug.LogError("[FirebaseRandomItemDisplay] Firebase error: " + task.Exception);
            }
        });
    }

    public void ClearDisplay()
    {
        titleText.text = "Loading...";
        descriptionText.text = "Loading...";
        itemImage.sprite = null;
    }
    public void RandomizeItem()
    {
        ClearDisplay();       // Clear instantly
        LoadRandomItem();     // Load new data
    }

    public void LoadRandomItem()
    {
        dbReference.Child("items").GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("[FirebaseRandomItemDisplay] Failed to read items: " + task.Exception);
                return;
            }

            if (task.IsCompletedSuccessfully)
            {
                DataSnapshot snapshot = task.Result;

                List<DataSnapshot> items = new List<DataSnapshot>();
                foreach (DataSnapshot item in snapshot.Children)
                {
                    items.Add(item);
                }

                if (items.Count == 0)
                {
                    Debug.LogWarning("[FirebaseRandomItemDisplay] No items found.");
                    return;
                }

                // Pick a random item
                int randomIndex = UnityEngine.Random.Range(0, items.Count);
                DataSnapshot selectedItem = items[randomIndex];

                string title = selectedItem.Child("title").Value?.ToString();
                string description = selectedItem.Child("description").Value?.ToString();
                string imageUrl = selectedItem.Child("image").Value?.ToString();

                // Update UI
                titleText.text = title ?? "No Title";
                descriptionText.text = description ?? "No Description";

                StartCoroutine(LoadImageFromURL(imageUrl));
            }
        });
    }

    IEnumerator LoadImageFromURL(string url)
    {
        if (string.IsNullOrEmpty(url))
        {
            Debug.LogWarning("[FirebaseRandomItemDisplay] Image URL is empty.");
            yield break;
        }

        using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(url))
        {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("[FirebaseRandomItemDisplay] Failed to load image: " + request.error);
            }
            else
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(request);
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);
                itemImage.sprite = sprite;
            }
        }
    }

}
