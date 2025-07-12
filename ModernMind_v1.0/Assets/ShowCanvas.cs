using UnityEngine;

public class ShowCanvas : MonoBehaviour
{
    public Scene1CanvasManager canvas;
    public GameObject circle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.SixthCanvasShow();
            circle.SetActive(false);
            Debug.Log("done");
        }
    }
}
