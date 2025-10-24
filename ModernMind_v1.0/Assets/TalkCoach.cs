using UnityEngine;

public class TalkCoach : MonoBehaviour
{
    public Scene3Redlight canvas;
    public GameObject circle;
    public GameObject one, two, three, four, five;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.FourteenthCanvasShow();
            circle.SetActive(false);
            one.SetActive(false);
            two.SetActive(false);
            three.SetActive(false);
            four.SetActive(false);
            five.SetActive(false);
            Debug.Log("done");
        }
    }
}
