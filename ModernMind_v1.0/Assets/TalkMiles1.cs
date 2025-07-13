using UnityEngine;

public class TalkMiles1 : MonoBehaviour
{
    public LayuninCanvas canvas;
    public GameObject circle, circle2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.LayuninCanvasShow();
            circle2.SetActive(true);
            circle.SetActive(false);
        }
    }
}
