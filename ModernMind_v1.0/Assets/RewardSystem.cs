using UnityEngine;

public class RewardSystem : MonoBehaviour
{
    private const string HintKey = "Hint";
    private const string FreezeKey = "Freeze";
    private const string SkipKey = "Skip";

    public void Hint()
    {
        int currentHint = PlayerPrefs.GetInt(HintKey, 0);
        PlayerPrefs.SetInt(HintKey, currentHint + 1);
        PlayerPrefs.Save();
    }

    public void Freeze()
    {
        int currentFreeze = PlayerPrefs.GetInt(FreezeKey, 0);
        PlayerPrefs.SetInt(FreezeKey, currentFreeze + 1);
        PlayerPrefs.Save();
    }

    public void Skip()
    {
        int currentSkip = PlayerPrefs.GetInt(SkipKey, 0);
        PlayerPrefs.SetInt(SkipKey, currentSkip + 1);
        PlayerPrefs.Save();
    }
}
