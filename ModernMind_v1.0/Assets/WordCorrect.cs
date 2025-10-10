using UnityEngine;

public class WordCorrect : MonoBehaviour
{
    public string letterValue;
    public GameObject Letter3D, Letter2D, ButtonUI, Bag, BagIcon, correct, wrong;
    public LetterCounter counter;
    [HideInInspector] public ItemPlacer placer;
    [HideInInspector] public int placedIndex = -1; // Track exact slot index
    public SetAllButtons allButtons;

    public void WordChecker()
    {
        string savedLetter = PlayerPrefs.GetString("CheckerWordValue", "None");
        Debug.Log($"[WordChecker] Checking {letterValue}, Saved={savedLetter}, Slot={placedIndex}");

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
            if (ButtonUI != null) Destroy(ButtonUI);
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
