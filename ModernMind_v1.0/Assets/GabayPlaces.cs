using UnityEngine;

public class GabayPlaces : MonoBehaviour
{
    public GabayCounter counter;
    public GameObject circle, check, layunin, bag, place, placeDone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            check.SetActive(true);
            layunin.SetActive(true);
            bag.SetActive(false);
            counter.PlaceCounter();
            circle.SetActive(false);
            place.SetActive(false);
            placeDone.SetActive(true);
            Debug.Log("done");
        }
    }
}
