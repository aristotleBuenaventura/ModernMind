using UnityEngine;

public class GrabLetter : MonoBehaviour
{
    public GameObject Letter3D, Letter2D;
    public int position;
    public ItemPlacer placer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Letter3D.SetActive(false);
            Letter2D.SetActive(true);
            placer.PlaceGrabbedItem(Letter2D);
        }
    }
}
