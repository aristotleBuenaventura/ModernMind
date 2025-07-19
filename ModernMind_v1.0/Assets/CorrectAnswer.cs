using UnityEngine;

public class CorrectAnswer : MonoBehaviour
{
    public GameObject PlayerCube, cube;
    public GameObject canvas, wrong, questionCanvas;
    public PlatformCounter counter;

    private bool hasTriggered = false; // Ensures it only runs once

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true;

            PlayerCube.transform.position = cube.transform.position;
            counter.counterPlus();
            canvas.SetActive(true);
            wrong.SetActive(false);
            questionCanvas.SetActive(false);
        }
    }
}
