using UnityEngine;

public class GabayCounter : MonoBehaviour
{
    public int counter = 0;

    public void PlaceCounter()
    {
        counter++;
        Debug.Log("PLACES: " + counter);
        if (counter == 9)
        {
            Debug.Log("DONE PLACES");
        }
    }
}
