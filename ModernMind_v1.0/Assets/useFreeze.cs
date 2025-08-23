using UnityEngine;

public class UseFreeze : MonoBehaviour
{
    public GameObject withStock, noStock;

    public void UseFreezePower()
    {
        int currentCount = PlayerPrefs.GetInt("freeze", 0);

        if (currentCount > 0)
        {
            currentCount--;
            PlayerPrefs.SetInt("freeze", currentCount);
            PlayerPrefs.Save();

            Debug.Log($"freeze used. Remaining: {currentCount}");

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
            Debug.LogWarning("No freeze left to use!");
        }
    }
}
