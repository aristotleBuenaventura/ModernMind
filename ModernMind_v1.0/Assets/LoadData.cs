using UnityEngine;
using TMPro;

public class LoadData : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI hintText;
    public TextMeshProUGUI freezeText;
    public TextMeshProUGUI skipText;
    public TextMeshProUGUI coinsText; // 🔥 New reference for coins display

    [Header("Buttons / States")]
    public GameObject hintUse, hintNo, freezeUse, freezeNo, skipUse, skipNo;

    void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        int hintCount = PlayerPrefs.GetInt("hint", 0);
        int freezeCount = PlayerPrefs.GetInt("freeze", 0);
        int skipCount = PlayerPrefs.GetInt("skip", 0);
        int coins = PlayerPrefs.GetInt("coins", 0); // 🔥 Load coins

        // Update counts
        if (hintText != null) hintText.text = "x" + hintCount;
        if (freezeText != null) freezeText.text = "x" + freezeCount;
        if (skipText != null) skipText.text = "x" + skipCount;
        if (coinsText != null) coinsText.text = coins.ToString(); // 🔥 Update coins UI

        // Enable/Disable buttons
        if (hintUse != null && hintNo != null)
        {
            bool hasHint = hintCount > 0;
            hintUse.SetActive(hasHint);
            hintNo.SetActive(!hasHint);
        }

        if (freezeUse != null && freezeNo != null)
        {
            bool hasFreeze = freezeCount > 0;
            freezeUse.SetActive(hasFreeze);
            freezeNo.SetActive(!hasFreeze);
        }

        if (skipUse != null && skipNo != null)
        {
            bool hasSkip = skipCount > 0;
            skipUse.SetActive(hasSkip);
            skipNo.SetActive(!hasSkip);
        }
    }
}
