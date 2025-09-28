using UnityEngine;
using TMPro;

public class RewardSystem : MonoBehaviour
{
    // Keys for PlayerPrefs
    private const string HintKey = "hint";
    private const string FreezeKey = "freeze";
    private const string SkipKey = "skip";

    public TextMeshProUGUI hintText;
    public TextMeshProUGUI freezeText;
    public TextMeshProUGUI skipText;

    public GameObject hintImage, freezeImage, skipImage;

    private void Start()
    {
        // Initialize UI with saved counts
        UpdateHintText();
        UpdateFreezeText();
        UpdateSkipText();
    }

    public void Hint()
    {
        int currentHint = PlayerPrefs.GetInt(HintKey, 0);
        currentHint++;
        PlayerPrefs.SetInt(HintKey, currentHint);
        PlayerPrefs.Save();
        hintImage.SetActive(false);

        UpdateHintText();
    }

    public void Freeze()
    {
        int currentFreeze = PlayerPrefs.GetInt(FreezeKey, 0);
        currentFreeze++;
        PlayerPrefs.SetInt(FreezeKey, currentFreeze);
        PlayerPrefs.Save();
        freezeImage.SetActive(false);
        UpdateFreezeText();
    }

    public void Skip()
    {
        int currentSkip = PlayerPrefs.GetInt(SkipKey, 0);
        currentSkip++;
        PlayerPrefs.SetInt(SkipKey, currentSkip);
        PlayerPrefs.Save();
        skipImage.SetActive(false);
        UpdateSkipText();
    }

    private void UpdateHintText()
    {
        if (hintText != null)
        {
            hintText.text = "x" + PlayerPrefs.GetInt(HintKey, 0);
        }
    }

    private void UpdateFreezeText()
    {
        if (freezeText != null)
        {
            freezeText.text = "x" + PlayerPrefs.GetInt(FreezeKey, 0);
        }
    }

    private void UpdateSkipText()
    {
        if (skipText != null)
        {
            skipText.text = "x" + PlayerPrefs.GetInt(SkipKey, 0);
        }
    }
}
