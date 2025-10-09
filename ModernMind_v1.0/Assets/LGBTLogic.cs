using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using TMPro;

[System.Serializable]
public class LGBTQItem
{
    public string key;
    public GameObject parentObj;
    public GameObject buttonObj;
    [TextArea] public string comments;
    [TextArea] public string scoreComments;
    [HideInInspector] public bool isDone = false;
}

public class LGBTQLogic : MonoBehaviour
{
    [Header("UI References")]
    public ShowUI bag;

    [Header("Objects")]
    public GameObject check;
    public GameObject circles;

    [Header("LGBTQ Items")]
    public List<LGBTQItem> lgbtqItems = new List<LGBTQItem>();

    [Header("Game Systems")]
    public CoinsValue coins;
    public TrackCoins newCoins;
    public TimerDisplay timer;

    [Header("UI Text")]
    public TextMeshProUGUI commentsLGBTQ;
    public TextMeshProUGUI commentsScore;

    // Scoring system for LGBTQ categories
    private readonly Dictionary<string, int> scoreRewards = new Dictionary<string, int>()
    {
        { "Lesbian", 5 },
        { "Gay", 5 },
        { "Bisexual", 5 },
        { "Transgender", 5 },
        { "Queer", 5 }
    };

    private void CheckAllDone()
    {
        // Check if all items are finished
        foreach (var item in lgbtqItems)
        {
            if (!item.isDone) return;
        }

        // All items completed
        timer.StartTimer();
        bag.UICanvasClose();
        check.SetActive(true);
        circles.SetActive(false);
        Debug.Log("✅ All LGBTQ items completed!");
    }

    private void FinishItem(LGBTQItem item, bool correct)
    {
        if (item.buttonObj != null)
            item.buttonObj.SetActive(false);
        if (item.parentObj != null)
            item.parentObj.SetActive(false);

        item.isDone = true;

        if (commentsLGBTQ != null)
            commentsLGBTQ.text = correct ? "Correct!" : item.comments;

        if (commentsScore != null)
            commentsScore.text = correct ? item.scoreComments : "";

        int done = 0;
        foreach (var t in lgbtqItems)
            if (t.isDone) done++;

        Debug.Log($"Progress: {done}/{lgbtqItems.Count} items done.");

        CheckAllDone();
    }

    public void CheckLogic(string categoryKey)
    {
        string savedValue = PlayerPrefs.GetString("CheckerValue");
        bag.UICanvasClose();

        GameObject pressedGO = EventSystem.current != null
            ? EventSystem.current.currentSelectedGameObject
            : null;

        LGBTQItem item = lgbtqItems.Find(x =>
            x.key == categoryKey &&
            pressedGO != null &&
            (x.buttonObj == pressedGO ||
             pressedGO.transform.IsChildOf(x.buttonObj.transform))
        );

        if (item == null)
        {
            Debug.LogWarning($"⚠️ No LGBTQItem found for key: {categoryKey} (pressedGO={pressedGO?.name})");
            return;
        }

        bool correct = (savedValue == categoryKey);

        if (correct)
        {
            if (scoreRewards.TryGetValue(categoryKey, out int reward))
            {
                coins.IncrementScore(reward);
                newCoins.IncrementScore(reward);
            }

            FinishItem(item, true);
        }
        else
        {
            FinishItem(item, false);
        }
    }
}
