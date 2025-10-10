using UnityEngine;

public class WordCorrect : MonoBehaviour
{
    public string letterValue;
    public GameObject Letter2D, ButtonUI, correct, wrong;
    public WordCounter counter;
    public TimerDisplay timer;
    [HideInInspector] public WordPlacer placer;
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
            Letter2D.SetActive(false);
            if (ButtonUI != null) Destroy(ButtonUI);
            
            if (counter.IsBelowWordCount)
            {
                correct.SetActive(true);
            }
            else
            {
                Debug.Log("All letters done!");
            }

            allButtons.SetAllButtonsActive(true);
        }
        else
        {
            Letter2D.SetActive(false);
            timer.DecreaseTime(30);
            if (placer != null && placedIndex >= 0)
            {
                placer.RemoveItemAt(placedIndex);
                placedIndex = -1; // reset after removal
            }
            allButtons.SetAllButtonsActive(true);
            Debug.Log($"[LetterChecker] ❌ Wrong! Expected {letterValue}, got {savedLetter}");
            wrong.SetActive(true);
        }
    }
}
