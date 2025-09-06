using UnityEngine;

public class ShowCanvasPuzzle : MonoBehaviour
{
    public GameObject canvas;
    public GameObject circle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.SetActive(true);
            circle.SetActive(false);
            Debug.Log("done");
        }
    }
}
