using UnityEngine;

public class WordPlacer : MonoBehaviour
{
    [Header("Assign your slot transforms here (where items should appear)")]
    public Transform[] slotPositions;

    private GameObject[] placedItems;   // Track which GameObjects are in each slot

    void Awake()
    {
        InitializeSlots();
    }

    // ✅ Ensure placedItems is always valid
    private void InitializeSlots()
    {
        if (slotPositions == null || slotPositions.Length == 0)
        {
            Debug.LogError("❌ ItemPlacer: slotPositions is not assigned in the Inspector!");
            return;
        }

        if (placedItems == null || placedItems.Length != slotPositions.Length)
        {
            placedItems = new GameObject[slotPositions.Length];
            Debug.Log($"✅ ItemPlacer initialized with {slotPositions.Length} slots.");
        }
    }

    // ✅ Place an item in the first available slot
    public void PlaceGrabbedItem(GameObject grabbedItem)
    {
        InitializeSlots(); // make sure arrays are ready

        if (grabbedItem == null)
        {
            Debug.LogError("❌ Tried to place a NULL grabbedItem!");
            return;
        }

        for (int i = 0; i < placedItems.Length; i++)
        {
            if (placedItems[i] == null) // free slot
            {
                // Move item into slot
                grabbedItem.transform.position = slotPositions[i].position;
                grabbedItem.transform.SetParent(slotPositions[i]);

                placedItems[i] = grabbedItem;

                // Track slot index in LetterCorrect
                WordCorrect lc = grabbedItem.GetComponent<WordCorrect>();
                if (lc != null)
                {
                    lc.placedIndex = i;
                    lc.placer = this;
                }

                // Track slot index in RemoveLetter
                RemoveWord rl = grabbedItem.GetComponent<RemoveWord>();
                if (rl != null)
                {
                    rl.placedIndex = i;
                    rl.placer = this;
                }

                Debug.Log($"✅ {grabbedItem.name} placed at slot {i}");
                return;
            }
        }

        Debug.LogWarning("⚠️ No free slots available!");
    }

    // ✅ Remove item at a given slot
    public void RemoveItemAt(int index)
    {
        InitializeSlots(); // make sure arrays are ready

        if (index >= 0 && index < placedItems.Length)
        {
            if (placedItems[index] != null)
            {
                Debug.Log($"🗑️ Removed {placedItems[index].name} from slot {index} → now free");
                placedItems[index] = null;
            }
            else
            {
                Debug.LogWarning($"⚠️ Slot {index} is already empty!");
            }
        }
        else
        {
            Debug.LogError($"❌ Invalid index {index} for removal!");
        }
    }

    // ✅ Check if any slot is free
    public bool HasFreeSlot()
    {
        InitializeSlots(); // make sure arrays are ready

        foreach (var item in placedItems)
        {
            if (item == null) return true;
        }
        return false;
    }
}
