using UnityEngine;
using System.Collections;

public class CameraCollision : MonoBehaviour
{
    public Transform player;
    public float smooth = 10f;
    public float minDistance = 1f;
    public float maxDistance = 4f;
    public float offsetY = 1.5f;

    private float currentDistance;

    // For shake
    private Vector3 originalPos;
    private Coroutine shakeCoroutine;

    void Start()
    {
        currentDistance = maxDistance;
        originalPos = transform.localPosition;
    }

    void LateUpdate()
    {
        Vector3 origin = player.position + Vector3.up * offsetY;

        RaycastHit hit;
        if (Physics.Raycast(origin, -transform.forward, out hit, maxDistance))
        {
            currentDistance = Mathf.Clamp(hit.distance, minDistance, maxDistance);
        }
        else
        {
            currentDistance = Mathf.Lerp(currentDistance, maxDistance, Time.deltaTime * smooth);
        }

        transform.position = player.position - transform.forward * currentDistance + Vector3.up * offsetY;
    }

    // 🔥 Simple shake with default values
    public void Shake()
    {
        if (shakeCoroutine != null) StopCoroutine(shakeCoroutine);
        shakeCoroutine = StartCoroutine(DoShake(0.3f, 0.2f)); // duration, intensity
    }

    private IEnumerator DoShake(float duration, float magnitude)
    {
        Vector3 startPos = transform.localPosition;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = startPos + new Vector3(x, y, 0);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = startPos;
        shakeCoroutine = null;
    }
}
