using UnityEngine;

public class WrongAnswer : MonoBehaviour
{
    public GameObject platform;
    public PlatformCounter counter;

    private bool hasTriggered = false; // Ensures it only runs once

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true;

            platform.SetActive(false);
            counter.counterIncrement();
        }
    }
}
