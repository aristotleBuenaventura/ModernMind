using UnityEngine;

public class TalkMaya : MonoBehaviour
{
    public Scene3Redlight canvas;
    public GameObject circle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.FourteenthCanvasShow();
            circle.SetActive(false);
            Debug.Log("done");
        }
    }
}
