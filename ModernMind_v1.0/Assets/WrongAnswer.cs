using UnityEngine;
using System.Collections;

public class WrongAnswer : MonoBehaviour
{
    public GameObject platform, correct, correctAnswer;
    public PlatformCounter counter;

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true;
            StartCoroutine(ShakeAndDisable());
            counter.counterIncrement();
            correctAnswer.SetActive(false);
        }
    }

    private IEnumerator ShakeAndDisable()
    {
        Vector3 originalPos = platform.transform.position;
        float shakeDuration = 5f;
        float elapsed = 0f;
        float magnitude = 0.05f;

        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-magnitude, magnitude);
            float y = Random.Range(-magnitude, magnitude);
            float z = Random.Range(-magnitude, magnitude);

            platform.transform.position = originalPos + new Vector3(x, y, z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Reset position and disable platform
        platform.transform.position = originalPos;
        platform.SetActive(false);
        correct.SetActive(false);
    }
}
