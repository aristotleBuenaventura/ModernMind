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
            // ✅ Check if there is still space in ItemPlacer
            if (placer != null && placer.HasFreeSlot())
            {
                Letter3D.SetActive(false);
                Letter2D.SetActive(true);

                // Place this letter in the next free position
                placer.PlaceGrabbedItem(Letter2D);
            }
            else
            {
                Debug.Log("❌ Cannot grab: all positions are already filled!");
            }
        }
    }
}
