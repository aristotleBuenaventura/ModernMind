using UnityEngine;

public class GrabWord : MonoBehaviour
{
    public GameObject Letter3D, Letter2D, punoCanvas;
    public WordPlacer placer;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (placer == null)
        {
            Debug.LogError("❌ GrabLetter: placer is NOT assigned in the Inspector!");
            return;
        }

        if (placer.HasFreeSlot())
        {
            Letter3D.SetActive(false);
            Letter2D.SetActive(true);

            placer.PlaceGrabbedItem(Letter2D);
        }
        else
        {
            punoCanvas.SetActive(true);
            Debug.Log("❌ Cannot grab: all positions are already filled!");
        }
    }
}
