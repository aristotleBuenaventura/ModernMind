using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using TMPro;

[System.Serializable]
public class ProductMazeItem
{
    public string key;             // e.g. "kultura", "migrasyon", etc.
    public GameObject parentObj;   // parent object to hide
    public GameObject buttonObj;   // button to hide
    [TextArea] public string comments; // message shown on wrong answer
    [HideInInspector] public bool isDone = false;
}

public class ProductMazeLogic : MonoBehaviour
{
    [Header("UI References")]
    public TrashResultClose result;
    public ShowUI bag;
    public ShowUI task;

    [Header("Trash Items")]
    public List<ProductMazeItem> trashItems = new List<ProductMazeItem>();

    [Header("Game Systems")]
    public CoinsValue coins;
    public TrackCoins newCoins;
    public TimerDisplay timer;

    [Header("UI Text")]
    public TextMeshProUGUI commentsTrash; // global TMP text to show feedback

    // Score rewards for each trash type
    private readonly Dictionary<string, int> scoreRewards = new Dictionary<string, int>()
    {
        { "kultura", 10 },
        { "migrasyon", 10 },
        { "kalakalan", 10 },
        { "teknolohiya", 10 }
    };

    private void CheckAllDone()
    {
        foreach (var item in trashItems)
        {
            if (!item.isDone) return; // bail if any unfinished
        }

        // If all are done
        Debug.Log("ALLDONE");
        timer.StartTimer();
        result.ResultClose();
        bag.UICanvasClose();
    }

    // Centralized finishing logic; always calls CheckAllDone()
    private void FinishItem(ProductMazeItem item, bool correct)
    {
        if (item.buttonObj != null) item.buttonObj.SetActive(false);
        if (item.parentObj != null) item.parentObj.SetActive(false);

        item.isDone = true;

        if (commentsTrash != null)
            commentsTrash.text = correct ? "Correct!" : item.comments;

        // Progress log
        int done = 0;
        foreach (var t in trashItems) if (t.isDone) done++;
        Debug.Log($"Progress: {done}/{trashItems.Count} items done.");

        CheckAllDone();
    }

    // Call this from the Button’s OnClick, passing in its key
    public void CheckLogic(string colorKey)
    {
        string savedValue = PlayerPrefs.GetString("productMazeCheckerValue");
        bag.UICanvasClose();

        GameObject pressedGO = EventSystem.current != null ? EventSystem.current.currentSelectedGameObject : null;

        ProductMazeItem item = trashItems.Find(x =>
            x.key == colorKey &&
            pressedGO != null &&
            (x.buttonObj == pressedGO || pressedGO.transform.IsChildOf(x.buttonObj.transform))
        );

        if (item == null)
        {
            Debug.LogWarning($"No TrashItem found for key: {colorKey} (pressedGO={pressedGO?.name})");
            return;
        }

        bool correct = (savedValue == colorKey);

        if (correct)
        {
            result.TumpakShow();

            if (scoreRewards.TryGetValue(colorKey, out int reward))
            {
                coins.IncrementScore(reward);
                newCoins.IncrementScore(reward);
            }

            FinishItem(item, true);
        }
        else
        {
            result.MaliShow();
            FinishItem(item, false);
        }
    }
}
