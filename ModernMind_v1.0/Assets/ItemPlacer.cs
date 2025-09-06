using UnityEngine;

public class ItemPlacer : MonoBehaviour
{
    [Header("Assign your position GameObjects here")]
    public GameObject[] positions;

    [Header("Assign your item GameObjects here")]
    public GameObject[] items;

    private int currentPositionIndex = 0; // 👈 Counter for the next available slot

    // ✅ Helper function so GrabLetter can check before grabbing
    public bool HasFreeSlot()
    {
        return currentPositionIndex < positions.Length;
    }

    // 👇 Callable function to place a grabbed item in sequence
    public void PlaceGrabbedItem(GameObject grabbedItem)
    {
        if (grabbedItem == null) return;

        if (currentPositionIndex >= positions.Length)
        {
            Debug.Log("⚠️ Limit reached: All positions are already filled!");
            return;
        }

        grabbedItem.transform.position = positions[currentPositionIndex].transform.position;
        grabbedItem.transform.rotation = positions[currentPositionIndex].transform.rotation;

        currentPositionIndex++;
    }
}
