using UnityEngine;

public class DataReset : MonoBehaviour
{
    public CoinsValue coins;

    void Start()
    {
        ResetData();
    }

    public void ResetData()
    {
        // Reset values
        PlayerPrefs.SetInt("hint", 0);
        PlayerPrefs.SetInt("freeze", 0);
        PlayerPrefs.SetInt("skip", 0);
        PlayerPrefs.SetInt("coins", 0);

        PlayerPrefs.Save();

        Debug.Log("✅ PlayerPrefs reset to 0");

        coins.ResetScore();
        
    }
}
