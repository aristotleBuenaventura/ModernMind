using UnityEngine;

public class LetterCorrect : MonoBehaviour
{
    public string letterValue;
    public GameObject Letter3D, Letter2D, QuestionMark, ButtonUI, Circle, Bag, BagIcon, correct, wrong;
    public LetterCounter counter;
    public ItemPlacer placer;

    [HideInInspector] public int placedIndex = -1; // ✅ store which slot this letter was placed in

    public void LetterChecker()
    {
        // Always fetch the latest saved letter
        string savedLetter = PlayerPrefs.GetString("LetterValue", "None");

        if (savedLetter == letterValue)
        {
            if (placer != null && placedIndex >= 0)
            {
                placer.RemoveItemAt(placedIndex); // ✅ free up that slot
            }

            counter.counterCheck();
            Letter3D.SetActive(true);
            Letter2D.SetActive(false);
            QuestionMark.SetActive(false);
            Destroy(ButtonUI);
            Circle.SetActive(false);
            Bag.SetActive(false);
            BagIcon.SetActive(true);
            correct.SetActive(true);
        }
        else
        {
            wrong.SetActive(true);
        }
    }
}
