using UnityEngine;

public class CorrectAnswer : MonoBehaviour
{
    public GameObject PlayerCube, cube;
    public GameObject wrong, questionCanvas, correctCanvas;
    public PlatformCounter counter;
    public KeyManager key;

    private bool hasTriggered = false; // Ensures it only runs once

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true;

            PlayerCube.transform.position = cube.transform.position;
            correctCanvas.SetActive(true);
            key.IncrementKey(1);
            counter.counterPlus();
            wrong.SetActive(false);
            questionCanvas.SetActive(false);
        }
    }
}
