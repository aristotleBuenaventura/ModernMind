using UnityEngine;

public class LetterCounter : MonoBehaviour
{
    private int counter;
    public int wordCount;
    public GameObject doneCanvas, removeCanvas;

    // ✅ Bool getter (true if not yet complete)
    public bool IsBelowWordCount => counter < wordCount;

    public void counterCheck()
    {
        counter++;
        Debug.Log("counter: " + counter);

        if (counter >= wordCount)
        {
            if (removeCanvas != null) removeCanvas.SetActive(false);
            Debug.Log("LETTER DONE");
            if (doneCanvas != null) doneCanvas.SetActive(true);
        }
    }
}
