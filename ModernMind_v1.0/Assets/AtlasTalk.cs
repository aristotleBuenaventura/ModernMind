using UnityEngine;

public class AtlasTalk : MonoBehaviour
{
    public GameObject circle;
    public Scene2CanvasManager dialogue;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogue.C14CanvasShow();
            circle.SetActive(false);
        }
    }
}
