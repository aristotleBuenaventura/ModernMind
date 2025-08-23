using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

[System.Serializable]
public class TrashItem
{
    public string key;             // e.g. "blue", "green", "black"
    public GameObject parentObj;   // parent object to hide
    public GameObject buttonObj;   // button to hide
    [HideInInspector] public bool isDone = false;
}

public class TrashLogic : MonoBehaviour
{
    [Header("UI References")]
    public TrashResultClose result;
    public ShowUI bag;
    public ShowUI task;

    [Header("Objects")]
    public GameObject check;
    public GameObject circles;

    [Header("Trash Items")]
    public List<TrashItem> trashItems = new List<TrashItem>();

    public CoinsValue coins;

    private void CheckAllDone()
    {
        foreach (var item in trashItems)
        {
            if (!item.isDone) return; // stop if any unfinished
        }

        // If all are done
        Debug.Log("ALLDONE");
        result.ResultClose();
        bag.UICanvasClose();
        task.UICanvasShow();
        check.SetActive(true);
        circles.SetActive(false);
    }

    // ✅ Call this from the Button’s OnClick, passing in its buttonObj
    public void CheckLogic(string colorKey)
    {
        string savedValue = PlayerPrefs.GetString("CheckerValue");
        bag.UICanvasClose();

        // detect which button was pressed
        GameObject pressedButton = EventSystem.current.currentSelectedGameObject;

        TrashItem item = trashItems.Find(x => x.key == colorKey && x.buttonObj == pressedButton);
        if (item == null)
        {
            Debug.LogWarning($"No TrashItem found for key: {colorKey}");
            return;
        }

        if (savedValue == colorKey)
        {
            result.TumpakShow();
            coins.IncrementScore(5);
            if (item.buttonObj != null) item.buttonObj.SetActive(false);
            if (item.parentObj != null) item.parentObj.SetActive(false);
            item.isDone = true;
            CheckAllDone();
        }
        else
        {
            result.MaliShow();
        }
    }
}
