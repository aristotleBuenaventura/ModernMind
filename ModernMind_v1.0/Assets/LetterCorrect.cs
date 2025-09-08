using UnityEngine;

public class LetterCorrect : MonoBehaviour
{
    public string letterValue;
    public GameObject Letter3D, Letter2D, QuestionMark, ButtonUI, Circle, Bag, BagIcon, correct, wrong;
    public LetterCounter counter;
    [HideInInspector] public ItemPlacer placer;
    [HideInInspector] public int placedIndex = -1; // Track exact slot index
    public SetAllButtons allButtons;

    public void LetterChecker()
    {
        string savedLetter = PlayerPrefs.GetString("LetterValue", "None");
        Debug.Log($"[LetterChecker] Checking {letterValue}, Saved={savedLetter}, Slot={placedIndex}");

        if (savedLetter == letterValue)
        {
            if (placer != null && placedIndex >= 0)
            {
                placer.RemoveItemAt(placedIndex);
                placedIndex = -1; // reset after removal
            }

            counter?.counterCheck();
            Letter3D.SetActive(true);
            Letter2D.SetActive(false);
            QuestionMark.SetActive(false);
            if (ButtonUI != null) Destroy(ButtonUI);
            Circle.SetActive(false);
            Bag.SetActive(false);
            BagIcon.SetActive(true);
            
            if (counter.IsBelowWordCount)
            {
                correct.SetActive(true);
            }
            else
            {
                Debug.Log("All letters done!");
            }

            allButtons.SetAllButtonsActive(false);
        }
        else
        {
            Debug.Log($"[LetterChecker] ❌ Wrong! Expected {letterValue}, got {savedLetter}");
            wrong.SetActive(true);
        }
    }
}
