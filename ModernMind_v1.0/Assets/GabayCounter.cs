using UnityEngine;

public class GabayCounter : MonoBehaviour
{
    public int counter = 0;
    public GameObject Resulta;

    public void PlaceCounter()
    {
        counter++;
        Debug.Log("PLACES: " + counter);
        if (counter == 9)
        {
            Resulta.SetActive(true);
            Debug.Log("DONE PLACES");
        }
    }
}
