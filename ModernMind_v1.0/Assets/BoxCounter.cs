using UnityEngine;

public class BoxCounter : MonoBehaviour
{
    private int counter = 0;

    public void CounterIncrement()
    {
        counter++;
        if (counter == 5)
        {
            Debug.Log("BOXES DONE!!!");
        }
    }
}
