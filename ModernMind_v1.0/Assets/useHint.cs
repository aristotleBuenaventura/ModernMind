using UnityEngine;

public class UseHint : MonoBehaviour
{
    public GameObject withStock, noStock;

    public void UseHintPower()
    {
        int currentCount = PlayerPrefs.GetInt("hint", 0);

        if (currentCount > 0)
        {
            currentCount--;
            PlayerPrefs.SetInt("hint", currentCount);
            PlayerPrefs.Save();

            Debug.Log($"Hint used. Remaining: {currentCount}");

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
            Debug.LogWarning("No hints left to use!");
        }
    }
}
