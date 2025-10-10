using UnityEngine;
using TMPro;

public class WoodCounter : MonoBehaviour
{
    [Header("UI Reference")]
    public TextMeshProUGUI counterText; // ✅ Assign your TMP text in the Inspector

    [Header("Wood Display")]
    public GameObject[] woodVisuals = new GameObject[5]; // ✅ 5 wood GameObjects (behind player)

    [Header("Settings")]
    public int woodCount = 0; // current amount of wood

    private void Start()
    {
        UpdateText();
        UpdateWoodVisuals();
    }

    // ✅ Add wood
    public void Increment()
    {
        if (woodCount < woodVisuals.Length)
        {
            woodCount++;
            UpdateText();
            UpdateWoodVisuals();
            Debug.Log($"🪵 Wood increased → {woodCount}");
        }
        else
        {
            Debug.LogWarning("⚠️ Cannot carry more wood!");
        }
    }

    // ✅ Remove wood (minimum 0)
    public void Decrement()
    {
        if (woodCount > 0)
        {
            woodCount--;
            UpdateText();
            UpdateWoodVisuals();
            Debug.Log($"🪓 Wood decreased → {woodCount}");
        }
        else
        {
            Debug.LogWarning("⚠️ Cannot decrease — wood count already at 0.");
        }
    }

    // ✅ Refresh TMP text
    private void UpdateText()
    {
        if (counterText != null)
        {
            counterText.text = $"x {woodCount}";
        }
        else
        {
            Debug.LogWarning("⚠️ No TextMeshProUGUI assigned to WoodCounter!");
        }
    }

    // ✅ Toggle wood GameObjects visibility
    private void UpdateWoodVisuals()
    {
        for (int i = 0; i < woodVisuals.Length; i++)
        {
            if (woodVisuals[i] != null)
            {
                // Show only up to current count
                woodVisuals[i].SetActive(i < woodCount);
            }
        }
    }
}
