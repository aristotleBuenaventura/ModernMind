using UnityEngine;

public class PuzzlePieceCounter : MonoBehaviour
{
    [SerializeField] private int counter = 0;  // serialized so you can monitor in Inspector
    [SerializeField] private int maxCounter = 0;

    public void CounterCheck()
    {
        if (counter < maxCounter)
        {
            counter++;
        }

        if (counter >= maxCounter && maxCounter > 0)
        {
            Debug.Log("PUZZLE DONE");
        }
    }

    public void ResetCounter()
    {
        counter = 0;
    }
}
