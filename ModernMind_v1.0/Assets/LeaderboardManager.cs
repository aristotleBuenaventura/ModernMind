using UnityEngine;
using TMPro;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System.Collections.Generic;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{
    [Header("Leaderboard UI")]
    [SerializeField] private TextMeshProUGUI[] nameTexts;
    [SerializeField] private TextMeshProUGUI[] scoreTexts;
    [SerializeField] private Button[] infoButtons;

    [Header("Player Details Canvases")]
    [SerializeField] private GameObject[] playerDetailCanvases; // 3 canvases
    [SerializeField] private TextMeshProUGUI[] playerNameTexts;  // 3 player names, one per canvas

    [Header("Stage Coins per Canvas")]
    [SerializeField] private TextMeshProUGUI[] level1StageTexts; // 3 TMPs for Level1 stages
    [SerializeField] private TextMeshProUGUI[] level2StageTexts; // 3 TMPs for Level2 stages
    [SerializeField] private TextMeshProUGUI[] level3StageTexts; // 3 TMPs for Level3 stages

    [Header("Total Coins per Level")]
    [SerializeField] private TextMeshProUGUI[] levelTotalCoinsTexts; // 3 TMPs, one per level

    private DatabaseReference dbReference;
    private bool isReady = false;
    private List<string> playerNames = new List<string>();

    private void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Result == DependencyStatus.Available)
            {
                string databaseUrl = "https://modernmind-142ff-default-rtdb.firebaseio.com/";
                FirebaseDatabase database = FirebaseDatabase.GetInstance(FirebaseApp.DefaultInstance, databaseUrl);
                dbReference = database.RootReference;
                isReady = true;
                RefreshLeaderboard();
            }
        });
    }

    public void RefreshLeaderboard()
    {
        if (!isReady) return;

        dbReference.Child("users")
            .OrderByChild("score")
            .LimitToLast(15)
            .GetValueAsync()
            .ContinueWithOnMainThread(task =>
            {
                if (task.IsCompletedSuccessfully)
                {
                    DataSnapshot snapshot = task.Result;
                    List<(string name, int score)> leaderboard = new List<(string, int)>();
                    playerNames.Clear();

                    foreach (DataSnapshot child in snapshot.Children)
                    {
                        string username = child.Key;
                        int score = 0;
                        if (child.Child("score").Exists)
                            int.TryParse(child.Child("score").Value.ToString(), out score);
                        leaderboard.Add((username, score));
                    }

                    leaderboard.Sort((a, b) => b.score.CompareTo(a.score));

                    for (int i = 0; i < nameTexts.Length; i++)
                    {
                        if (i < leaderboard.Count)
                        {
                            nameTexts[i].text = leaderboard[i].name;
                            scoreTexts[i].text = leaderboard[i].score.ToString();
                            playerNames.Add(leaderboard[i].name);

                            int index = i;
                            infoButtons[i].onClick.RemoveAllListeners();
                            infoButtons[i].onClick.AddListener(() => ShowPlayerDetails(playerNames[index]));
                            infoButtons[i].gameObject.SetActive(true);
                        }
                        else
                        {
                            nameTexts[i].text = "-";
                            scoreTexts[i].text = "0";
                            infoButtons[i].gameObject.SetActive(false);
                        }
                    }
                }
            });
    }

    private void ShowPlayerDetails(string username)
    {
        dbReference.Child("users").Child(username).Child("levels").GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (!task.IsCompletedSuccessfully) return;
            DataSnapshot levelsSnapshot = task.Result;

            int canvasIndex = 0;
            foreach (DataSnapshot level in levelsSnapshot.Children)
            {
                if (canvasIndex >= playerDetailCanvases.Length) break;

                playerDetailCanvases[canvasIndex].SetActive(true);
                playerNameTexts[canvasIndex].text = username;

                int stage1Coins = level.Child("stage1Coins").Exists ? int.Parse(level.Child("stage1Coins").Value.ToString()) : 0;
                int stage2Coins = level.Child("stage2Coins").Exists ? int.Parse(level.Child("stage2Coins").Value.ToString()) : 0;
                int stage3Coins = level.Child("stage3Coins").Exists ? int.Parse(level.Child("stage3Coins").Value.ToString()) : 0;

                int totalCoins = stage1Coins + stage2Coins + stage3Coins;

                if (canvasIndex == 0)
                {
                    level1StageTexts[0].text = stage1Coins.ToString();
                    level1StageTexts[1].text = stage2Coins.ToString();
                    level1StageTexts[2].text = stage3Coins.ToString();
                    levelTotalCoinsTexts[0].text = totalCoins.ToString();
                }
                else if (canvasIndex == 1)
                {
                    level2StageTexts[0].text = stage1Coins.ToString();
                    level2StageTexts[1].text = stage2Coins.ToString();
                    level2StageTexts[2].text = stage3Coins.ToString();
                    levelTotalCoinsTexts[1].text = totalCoins.ToString();
                }
                else if (canvasIndex == 2)
                {
                    level3StageTexts[0].text = stage1Coins.ToString();
                    level3StageTexts[1].text = stage2Coins.ToString();
                    level3StageTexts[2].text = stage3Coins.ToString();
                    levelTotalCoinsTexts[2].text = totalCoins.ToString();
                }

                canvasIndex++;
            }

            for (; canvasIndex < playerDetailCanvases.Length; canvasIndex++)
                playerDetailCanvases[canvasIndex].SetActive(false);
        });
    }

    public void ClosePlayerDetails()
    {
        foreach (var canvas in playerDetailCanvases)
            canvas.SetActive(false);
    }
}
