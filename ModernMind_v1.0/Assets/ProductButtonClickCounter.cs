using UnityEngine;

public class ProductButtonClickCounter : MonoBehaviour
{
    private int counter = 0;
    public BoxManager box;

    public void CounterIncrement()
    {
        counter++;
        if (counter == 3)
        {
            box.ResetBoxes();
        }
    }
}
