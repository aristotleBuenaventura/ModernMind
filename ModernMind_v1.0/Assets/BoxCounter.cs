using UnityEngine;

public class BoxCounter : MonoBehaviour
{
    private int counter = 0;
    public GameObject Results;

    public void CounterIncrement()
    {
        counter++;
        if (counter == 5)
        {
            Results.SetActive(true);
            Debug.Log("BOXES DONE!!!");
        }
    }
}
