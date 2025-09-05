using UnityEngine;

public class LetterCorrect : MonoBehaviour
{
    public string letterValue;
    public GameObject Letter3D, Letter2D, QuestionMark, ButtonUI, Circle, Bag, BagIcon, correct, wrong;
    public LetterCounter counter;

    public void LetterChecker()
    {
        // Always fetch the latest saved letter
        string savedLetter = PlayerPrefs.GetString("LetterValue", "None");

        if (savedLetter == letterValue)
        {
            counter.counterCheck();
            Letter3D.SetActive(true);
            Letter2D.SetActive(false);
            QuestionMark.SetActive(false);
            ButtonUI.SetActive(false);
            Circle.SetActive(false);
            Bag.SetActive(false);
            BagIcon.SetActive(true);
            correct.SetActive(true);
        }
        else
        {
            wrong.SetActive(true);
            // Optional: reset visibility if not matched
            //Letter3D.SetActive(false);
            //Letter2D.SetActive(true);
            //QuestionMark.SetActive(true);
            //ButtonUI.SetActive(true);
            //Circle.SetActive(true);
        }
    }
}
