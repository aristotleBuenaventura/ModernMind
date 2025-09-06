using UnityEngine;

public class ItemPlacer : MonoBehaviour
{
    [Header("Assign your position GameObjects here (optional, will auto-detect if empty)")]
    public GameObject[] positions;

    [Header("Assign your item GameObjects here (optional)")]
    public GameObject[] items;

    private bool[] slotOccupied; // ✅ Tracks if a slot has an item

    private void Awake()
    {
        // If positions not assigned, auto-detect child objects
        if (positions == null || positions.Length == 0)
        {
            int childCount = transform.childCount;
            positions = new GameObject[childCount];
            for (int i = 0; i < childCount; i++)
            {
                positions[i] = transform.GetChild(i).gameObject;
            }
            Debug.Log($"[ItemPlacer] Auto-detected {positions.Length} positions from children.");
        }

        InitializeSlots();
    }

    // ✅ Initialize slots safely
    private void InitializeSlots()
    {
        if (positions == null)
        {
            Debug.LogError("❌ ItemPlacer has no positions assigned!");
            return;
        }

        slotOccupied = new bool[positions.Length];
        for (int i = 0; i < slotOccupied.Length; i++)
        {
            slotOccupied[i] = false; // default: all empty
        }
    }

    // ✅ Check if any slot is available
    public bool HasFreeSlot()
    {
        if (slotOccupied == null || slotOccupied.Length != positions.Length)
        {
            InitializeSlots(); // re-init if needed
        }

        for (int i = 0; i < slotOccupied.Length; i++)
        {
            if (!slotOccupied[i]) return true; // found empty slot
        }
        return false;
    }

    // ✅ Place item in the first free slot
    public void PlaceGrabbedItem(GameObject grabbedItem)
    {
        if (grabbedItem == null) return;

        if (slotOccupied == null || slotOccupied.Length != positions.Length)
        {
            InitializeSlots();
        }

        for (int i = 0; i < positions.Length; i++)
        {
            if (!slotOccupied[i])
            {
                grabbedItem.transform.position = positions[i].transform.position;
                grabbedItem.transform.rotation = positions[i].transform.rotation;

                slotOccupied[i] = true; // mark as filled

                // ✅ Tell the letter which slot it's in
                LetterCorrect lc = grabbedItem.GetComponent<LetterCorrect>();
                if (lc != null)
                {
                    lc.placedIndex = i;
                }

                Debug.Log($"✅ Item placed in slot {i}");
                return;
            }
        }

        Debug.Log("⚠️ No free slots available!");
    }

    // ✅ Remove item from a specific slot
    public void RemoveItemAt(int index)
    {
        if (positions == null || slotOccupied == null)
        {
            Debug.LogError("❌ RemoveItemAt failed: positions/slotOccupied not initialized.");
            return;
        }

        if (index < 0 || index >= positions.Length)
        {
            Debug.LogWarning("⚠️ Invalid index passed to RemoveItemAt");
            return;
        }

        if (slotOccupied[index])
        {
            slotOccupied[index] = false; // free up slot
            Debug.Log($"🗑️ Slot {index} is now free again");
        }
        else
        {
            Debug.Log($"⚠️ Slot {index} was already empty");
        }
    }

    // ✅ Check if a specific slot is occupied
    public bool IsSlotOccupied(int index)
    {
        if (slotOccupied == null || index < 0 || index >= positions.Length) return false;
        return slotOccupied[index];
    }
}
