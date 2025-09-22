using UnityEngine;

public class AtlasDialogue : MonoBehaviour
{
    public GameObject circle;
    public Scene2MazeCanvasManager canvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.Atlas6CanvasShow();
            circle.SetActive(false);

        }
    }
}
