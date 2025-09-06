using UnityEngine;

public class RemoveLetter : MonoBehaviour
{
    [HideInInspector] public ItemPlacer placer;
    [HideInInspector] public int placedIndex = -1; // Track exact slot index
    public GameObject Letter3D, Letter2D;

    public void RemoveLetterArray()
    {
        if (placer == null)
        {
            Debug.LogError($"❌ {name}: No ItemPlacer assigned!");
            return;
        }

        if (placedIndex < 0)
        {
            Debug.LogWarning($"⚠️ {name}: Tried to remove but no valid slot index!");
            return;
        }

        // ✅ Free up the slot
        placer.RemoveItemAt(placedIndex);

        // ✅ Reset visuals
        if (Letter2D != null) Letter2D.SetActive(false);
        if (Letter3D != null) Letter3D.SetActive(true);

        Debug.Log($"🗑️ {name} removed from slot {placedIndex}");

        placedIndex = -1; // reset after removal
    }
}
