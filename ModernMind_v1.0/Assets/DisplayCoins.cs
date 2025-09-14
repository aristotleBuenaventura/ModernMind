using UnityEngine;
using TMPro; // ✅ Needed for TextMeshProUGUI

public class DisplayCoins : MonoBehaviour
{
    public TrackCoins coins;             // Reference to your CoinsValue script
    public TextMeshProUGUI scoreText;    // Reference to TMPRO UI

    void Start()
    {
        // Show initial score
        scoreText.text = coins.GetScore().ToString();
    }

    void Update()
    {
        // 🔥 Keep updating display every frame
        scoreText.text = coins.GetScore().ToString();
    }
}
