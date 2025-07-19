using UnityEngine;
using System.Collections;

public class WrongAnswer : MonoBehaviour
{
    public GameObject platform, correct, correctAnswer;
    public PlatformCounter counter;
    public GameObject Crack1, Crack2, Crack3;

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
        }
    }

    private IEnumerator ShakeAndDisable()
    {
        Vector3 originalPos = platform.transform.position;
        float shakeDuration = 5f;
        float elapsed = 0f;
        float magnitude = 0.05f;

        // Start crack timers
        StartCoroutine(ShowCrackEffects());

        while (elapsed < shakeDuration)
        {
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
        yield return new WaitForSeconds(0f);
        Crack1.SetActive(true);

        yield return new WaitForSeconds(1f); // now total 2s
        Crack2.SetActive(true);

        yield return new WaitForSeconds(1f); // now total 4s
        Crack3.SetActive(true);
    }
}
