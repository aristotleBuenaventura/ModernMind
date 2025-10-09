using UnityEngine;

public class ShowDialogueBridge : MonoBehaviour
{
    public GameObject circle, canvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.SetActive(true);
            circle.SetActive(false);
        }
    }
}
