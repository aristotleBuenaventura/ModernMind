using UnityEngine;

public class LetterCounter : MonoBehaviour
{
    private int counter;
    public int wordCount;
    public GameObject doneCanvas, removeCanvas;
    
    public void counterCheck()
    {
        counter++;
        Debug.Log("counter: " + counter);
        if (counter >= wordCount)
        {
            removeCanvas.SetActive(false);
            Debug.Log("LETTER DONE");
            doneCanvas.SetActive(true);
        }
    }
}
