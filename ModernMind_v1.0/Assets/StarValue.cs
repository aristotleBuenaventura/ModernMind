using UnityEngine;
using TMPro;

public class StarValue : MonoBehaviour
{
    [Header("Messages for Each Star Level")]
    [TextArea(2, 5)] public string[] oneStarMessages;
    [TextArea(2, 5)] public string[] twoStarMessages;
    [TextArea(2, 5)] public string[] threeStarMessages;

    public KeyManager keyValue;

    public GameObject oneStar, twoStar, threeStar;
    public TextMeshProUGUI messageDisplay;

    private int currentTier = -1; // -1 means nothing has been shown yet

    void Update()
    {
        int keyCount = keyValue.GetKeyCount();
        int newTier = GetStarTier(keyCount);

        // Only update if star tier has changed
        if (newTier != currentTier)
        {
            currentTier = newTier;

            // Reset all star displays
            oneStar.SetActive(false);
            twoStar.SetActive(false);
            threeStar.SetActive(false);

            // Show correct star and message
            switch (newTier)
            {
                case 1:
                    ShowMessage(oneStarMessages);
                    oneStar.SetActive(true);
                    break;
                case 2:
                    ShowMessage(twoStarMessages);
                    twoStar.SetActive(true);
                    break;
                case 3:
                    ShowMessage(threeStarMessages);
                    threeStar.SetActive(true);
                    break;
                default:
                    messageDisplay.text = ""; // Clear text if out of range
                    break;
            }
        }
    }

    int GetStarTier(int keyCount)
    {
        if (keyCount >= 0 && keyCount <= 14)
            return 1;
        else if (keyCount >= 15 && keyCount <= 18)
            return 2;
        else if (keyCount >= 19 && keyCount <= 20) // Adjusted to >= 4 if you want the 3-star to show earlier
            return 3;
        else
            return 0;
    }

    void ShowMessage(string[] messages)
    {
        if (messages.Length == 0 || messageDisplay == null) return;

        int randomIndex = Random.Range(0, messages.Length);
        messageDisplay.text = messages[randomIndex];
    }
}
