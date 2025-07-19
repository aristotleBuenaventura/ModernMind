using UnityEngine;
using System.Collections;

public class WrongAnswer : MonoBehaviour
{
    public GameObject platform, correct, correctAnswer;
    public PlatformCounter counter;
    public GameObject Crack1, Crack2, Crack3, wrongCanvas;

    private bool hasTriggered = false;

    void Start()
    {
        Crack1.SetActive(false);
        Crack2.SetActive(false);
        Crack3.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true;
            StartCoroutine(ShakeAndDisable());
            counter.counterIncrement();
            correctAnswer.SetActive(false);
            wrongCanvas.SetActive(true);
        }
    }

    private IEnumerator ShakeAndDisable()
    {
        Vector3 originalPos = platform.transform.position;
        float shakeDuration = 5f;
        float elapsed = 0f;

        // Crack timers
        StartCoroutine(ShowCrackEffects());

        while (elapsed < shakeDuration)
        {
            // Intensity increases every second
            float intensityMultiplier = 1f + Mathf.Floor(elapsed); // goes from 1 to 5
            float magnitude = 0.05f * intensityMultiplier;

            float x = Random.Range(-magnitude, magnitude);
            float y = Random.Range(-magnitude, magnitude);
            float z = Random.Range(-magnitude, magnitude);

            platform.transform.position = originalPos + new Vector3(x, y, z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        platform.transform.position = originalPos;
        platform.SetActive(false);
        correct.SetActive(false);
    }

    private IEnumerator ShowCrackEffects()
    {
        yield return new WaitForSeconds(1f);
        Crack1.SetActive(true);

        yield return new WaitForSeconds(1f); // 2s total
        Crack2.SetActive(true);

        yield return new WaitForSeconds(2f); // 4s total
        Crack3.SetActive(true);
    }
}
