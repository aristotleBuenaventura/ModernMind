using UnityEngine;

public class ChestCounter : MonoBehaviour
{
    [SerializeField] private int chestCount;
    private int playerChestCount;
    public GameObject chestUI;

    public void SetChestCount(int value)
    {
        chestCount = value;
    }

    public void IncrementPlayerChest()
    {
        playerChestCount++;
        Debug.Log("Player Chest Count: " + playerChestCount);
        CheckIfDone();
    }

    public void SetPlayerChestCount()
    {
        playerChestCount = playerChestCount + 1;
        CheckIfDone();
    }

    private void CheckIfDone()
    {
        if (playerChestCount == chestCount)
        {
            Debug.Log("DONE - All chests collected!");
            chestUI.SetActive(false);
        }
    }
}
