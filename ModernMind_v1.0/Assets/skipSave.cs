using UnityEngine;

public class skipSave : MonoBehaviour
{
    public GameObject Puzzle1Finish, Puzzle2Finish, Puzzle3Finish, FirstLetter, SecondLetter, ThirdLetter;

    void Start()
    {
        OneP();
    }

    public void OneP()
    {
        PlayerPrefs.SetString("SearchSkip", "OneP");
        PlayerPrefs.Save();
    }

    public void OneL()
    {
        PlayerPrefs.SetString("SearchSkip", "OneL");
        PlayerPrefs.Save();
    }

    public void TwoP()
    {
        PlayerPrefs.SetString("SearchSkip", "TwoP");
        PlayerPrefs.Save();
    }

    public void TwoL()
    {
        PlayerPrefs.SetString("SearchSkip", "TwoL");
        PlayerPrefs.Save();
    }

    public void ThreeP()
    {
        PlayerPrefs.SetString("SearchSkip", "ThreeP");
        PlayerPrefs.Save();
    }

    public void ThreeL()
    {
        PlayerPrefs.SetString("SearchSkip", "ThreeL");
        PlayerPrefs.Save();
    }

    public void UseSkip()
    {
        string value = PlayerPrefs.GetString("SearchSkip", "");

        if (value == "OneP")
        {
            Puzzle1Finish.SetActive(true);
            Debug.Log("SearchSkip = OneP");
        }
        else if (value == "OneL")
        {
            FirstLetter.SetActive(true);
            Debug.Log("SearchSkip = OneL");
        }
        else if (value == "TwoP")
        {
            Puzzle2Finish.SetActive(true);
            Debug.Log("SearchSkip = TwoP");
        }
        else if (value == "TwoL")
        {
            SecondLetter.SetActive(true);
            Debug.Log("SearchSkip = TwoL");
        }
        else if (value == "ThreeP")
        {
            Puzzle3Finish.SetActive(true);
            Debug.Log("SearchSkip = ThreeP");
        }
        else if (value == "ThreeL")
        {
            ThirdLetter.SetActive(true);
            Debug.Log("SearchSkip = ThreeL");
        }
        else
        {
            Debug.Log("SearchSkip not set");
        }
    }
}
