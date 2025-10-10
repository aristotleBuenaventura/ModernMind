using UnityEngine;
using TMPro;

public class WoodCounter : MonoBehaviour
{
    [Header("UI Reference")]
    public TextMeshProUGUI counterText; // ✅ Assign your TMP text in the Inspector

    [Header("Settings")]
    public int woodCount = 0; // starting value

    private void Start()
    {
        UpdateText();
    }

    // ✅ Add wood
    public void Increment()
    {
        woodCount++;
        UpdateText();
        Debug.Log($"🪵 Wood increased → {woodCount}");
    }

    // ✅ Remove wood (minimum 0)
    public void Decrement()
    {
        if (woodCount > 0)
        {
            woodCount--;
            UpdateText();
            Debug.Log($"🪓 Wood decreased → {woodCount}");
        }
        else
        {
            Debug.LogWarning("⚠️ Cannot decrease — wood count already at 0.");
        }
    }

    // ✅ Refresh the TMP text
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
}
