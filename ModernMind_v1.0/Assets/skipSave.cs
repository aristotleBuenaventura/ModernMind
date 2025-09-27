using UnityEngine;

public class skipSave : MonoBehaviour
{
    void Start()
    {
        CheckSearchSkip();
    }

    public void OneP()
    {
        PlayerPrefs.SetString("SearchSkip", "OneP");
        PlayerPrefs.Save();
        CheckSearchSkip();
    }

    public void OneL()
    {
        PlayerPrefs.SetString("SearchSkip", "OneL");
        PlayerPrefs.Save();
        CheckSearchSkip();
    }

    public void TwoP()
    {
        PlayerPrefs.SetString("SearchSkip", "TwoP");
        PlayerPrefs.Save();
        CheckSearchSkip();
    }

    public void TwoL()
    {
        PlayerPrefs.SetString("SearchSkip", "TwoL");
        PlayerPrefs.Save();
        CheckSearchSkip();
    }

    public void ThreeP()
    {
        PlayerPrefs.SetString("SearchSkip", "ThreeP");
        PlayerPrefs.Save();
        CheckSearchSkip();
    }

    public void ThreeL()
    {
        PlayerPrefs.SetString("SearchSkip", "ThreeL");
        PlayerPrefs.Save();
        CheckSearchSkip();
    }

    private void CheckSearchSkip()
    {
        string value = PlayerPrefs.GetString("SearchSkip", "");

        if (value == "OneP")
        {
            Debug.Log("SearchSkip = OneP");
        }
        else if (value == "OneL")
        {
            Debug.Log("SearchSkip = OneL");
        }
        else if (value == "TwoP")
        {
            Debug.Log("SearchSkip = TwoP");
        }
        else if (value == "TwoL")
        {
            Debug.Log("SearchSkip = TwoL");
        }
        else if (value == "ThreeP")
        {
            Debug.Log("SearchSkip = ThreeP");
        }
        else if (value == "ThreeL")
        {
            Debug.Log("SearchSkip = ThreeL");
        }
        else
        {
            Debug.Log("SearchSkip not set");
        }
    }
}
