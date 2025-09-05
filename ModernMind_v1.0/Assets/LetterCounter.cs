using UnityEngine;

public class LetterCounter : MonoBehaviour
{
    private int counter;
    public int wordCount;
    
    public void counterCheck()
    {
        counter++;
        Debug.Log("counter: " + counter);
        if (counter >= wordCount)
        {
            Debug.Log("LETTER DONE");
        }
    }
}
