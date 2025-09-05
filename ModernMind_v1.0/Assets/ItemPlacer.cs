using UnityEngine;

public class ItemPlacer : MonoBehaviour
{
    [Header("Assign your position GameObjects here")]
    public GameObject[] positions;

    [Header("Assign your item GameObjects here")]
    public GameObject[] items;

    private int currentPositionIndex = 0; // 👈 Counter for the next available slot

    // 👇 Callable function to place a grabbed item in sequence
    public void PlaceGrabbedItem(GameObject grabbedItem)
    {
        if (grabbedItem == null) return;
        if (currentPositionIndex >= positions.Length) return; // No more slots

        // Move the grabbed item to the next available position
        grabbedItem.transform.position = positions[currentPositionIndex].transform.position;
        grabbedItem.transform.rotation = positions[currentPositionIndex].transform.rotation;

        // Advance the counter
        currentPositionIndex++;
    }
}
