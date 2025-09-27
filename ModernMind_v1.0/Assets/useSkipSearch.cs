using UnityEngine;

public class UseSkipSearch : MonoBehaviour
{
    public GameObject withStock, noStock;
    public skipSave skip;

    public void UseSkipPower()
    {
        int currentCount = PlayerPrefs.GetInt("skip", 0);

        if (currentCount > 0)
        {
            currentCount--;
            PlayerPrefs.SetInt("skip", currentCount);
            PlayerPrefs.Save();
            skip.UseSkip();
            Debug.Log($"skip used. Remaining: {currentCount}");

            // 🔥 Update the UI immediately
            LoadData loadData = FindObjectOfType<LoadData>();
            if (loadData != null)
            {
                loadData.UpdateUI();
            }
        }
        else
        {
            withStock.SetActive(false);
            noStock.SetActive(true);
            Debug.LogWarning("No skip left to use!");
        }
    }
}
