using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using TMPro;

[System.Serializable]
public class ProductItem
{
    public string key;
    public GameObject parentObj;
    public GameObject buttonObj;
    [TextArea] public string comments;
    [TextArea] public string scoreComments;
    [HideInInspector] public bool isDone = false;
}

public class ProductLogic : MonoBehaviour
{
    [Header("UI References")]
    public TrashResultClose result;
    public ShowUI bag;
    public ShowUI task;

    [Header("Objects")]
    public List<ProductItem> trashItems = new List<ProductItem>();

    [Header("Game Systems")]
    public CoinsValue coins;
    public TrackCoins newCoins;
    public TimerDisplay timer;

    [Header("UI Text")]
    public TextMeshProUGUI commentsTrash;
    public TextMeshProUGUI commentsScore;
    public GameObject boyArrow, playerArrow;

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
            if (!item.isDone) return;
        }
        Debug.Log("ALLDONE");
        timer.StartTimer();
        result.ResultClose();
        bag.UICanvasClose();
        boyArrow.SetActive(false);
        playerArrow.SetActive(false);
    }

    private void FinishItem(ProductItem item, bool correct)
    {
        if (item.buttonObj != null) item.buttonObj.SetActive(false);
        if (item.parentObj != null) item.parentObj.SetActive(false);
        item.isDone = true;
        if (commentsTrash != null) commentsTrash.text = correct ? "Correct!" : item.comments;
        if (commentsScore != null) commentsScore.text = correct ? item.scoreComments : "";
        int done = 0;
        foreach (var t in trashItems) if (t.isDone) done++;
        Debug.Log($"Progress: {done}/{trashItems.Count} items done.");
        CheckAllDone();
    }

    public void CheckLogic(string colorKey)
    {
        string savedValue = PlayerPrefs.GetString("productCheckerValue");
        bag.UICanvasClose();
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
            newCoins.IncrementScore(reward);
            FinishItem(item, true);
        }
        else
        {
            result.MaliShow();
            FinishItem(item, false);
        }
    }
}
