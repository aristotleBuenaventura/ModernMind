using UnityEngine;

public class UseFreeze : MonoBehaviour
{
    public GameObject withStock, noStock, bag, inventory;
    public TimerHopscotch timer;

    public void UseFreezePower()
    {
        int currentCount = PlayerPrefs.GetInt("freeze", 0);

        if (currentCount > 0)
        {
            currentCount--;
            PlayerPrefs.SetInt("freeze", currentCount);
            PlayerPrefs.Save();
            timer.FreezeTimerForSeconds(30);
            bag.SetActive(true);
            inventory.SetActive(false);
            Debug.Log($"freeze used. Remaining: {currentCount}");


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
