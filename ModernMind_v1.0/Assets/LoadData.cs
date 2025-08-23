using UnityEngine;
using TMPro;

public class LoadData : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI hintText;
    public TextMeshProUGUI freezeText;
    public TextMeshProUGUI skipText;
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

        if (hintText != null) hintText.text = "x" + hintCount;
        if (freezeText != null) freezeText.text = "x" + freezeCount;
        if (skipText != null) skipText.text = "x" + skipCount;

        if(hintCount <= 0)
        {
            hintUse.SetActive(false);
            hintNo.SetActive(true);
        }

        if (freezeCount <= 0)
        {
            freezeUse.SetActive(false);
            freezeNo.SetActive(true);
        }

        if (skipCount <= 0)
        {
            skipUse.SetActive(false);
            skipNo.SetActive(true);
        }
    }
}
