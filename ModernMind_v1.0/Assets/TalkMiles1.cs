using UnityEngine;

public class TalkMiles1 : MonoBehaviour
{
    public LayuninCanvas canvas;
    public GameObject circle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.LayuninCanvasShow();
            circle.SetActive(false);
        }
    }
}
