using UnityEngine;

public class TalkMaya : MonoBehaviour
{
    public Scene3Redlight canvas;
    public GameObject circle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.c20CanvasShow();
            circle.SetActive(false);
            Debug.Log("done");
        }
    }
}
