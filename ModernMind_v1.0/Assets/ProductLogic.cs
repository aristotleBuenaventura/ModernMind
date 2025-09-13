using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using TMPro;

[System.Serializable]
public class ProductItem
{
    public string key;             // e.g. "blue", "green", "black"
    public GameObject parentObj;   // parent object to hide
    public GameObject buttonObj;   // button to hide
    [TextArea] public string comments; // message shown on wrong answer
    [HideInInspector] public bool isDone = false;
}

public class ProductLogic : MonoBehaviour
{
    [Header("UI References")]
    public TrashResultClose result;
    public ShowUI bag;
    public ShowUI task;

    [Header("Objects")]
    //public GameObject check;
    //public GameObject circles;

    [Header("Trash Items")]
    public List<ProductItem> trashItems = new List<ProductItem>();

    [Header("Game Systems")]
    public CoinsValue coins;
    public TimerDisplay timer;

    [Header("UI Text")]
    //public TextMeshProUGUI commentsTrash; // global TMP text to show feedback

    //public GameObject Antas1Result, blueStore;

    // Score rewards for each trash type
    private readonly Dictionary<string, int> scoreRewards = new Dictionary<string, int>()
    {
        { "export", 5 },
        { "import", 3 },
        { "reject", 3 }
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
        //Antas1Result.SetActive(true);
        //blueStore.SetActive(true);
        //check.SetActive(true);
        //circles.SetActive(false);
    }

    // Centralized finishing logic; always calls CheckAllDone()
    private void FinishItem(ProductItem item, bool correct)
    {
        if (item.buttonObj != null) item.buttonObj.SetActive(false);
        if (item.parentObj != null) item.parentObj.SetActive(false);

        item.isDone = true;

        //if (commentsTrash != null)
        //    commentsTrash.text = correct ? "Correct!" : item.comments;

        // Optional: progress log
        int done = 0;
        foreach (var t in trashItems) if (t.isDone) done++;
        Debug.Log($"Progress: {done}/{trashItems.Count} items done.");

        CheckAllDone();
    }

    // Call this from the Button’s OnClick, passing in its color key
    public void CheckLogic(string colorKey)
    {
        string savedValue = PlayerPrefs.GetString("productCheckerValue");
        bag.UICanvasClose();

        // Detect which UI object was pressed (could be a child of the button)
        GameObject pressedGO = EventSystem.current != null ? EventSystem.current.currentSelectedGameObject : null;

        ProductItem item = trashItems.Find(x =>
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
                coins.IncrementScore(reward);

            FinishItem(item, true);   // ✅ calls CheckAllDone()
        }
        else
        {
            result.MaliShow();
            FinishItem(item, false);  // ✅ calls CheckAllDone() even on wrong
        }
    }
}
