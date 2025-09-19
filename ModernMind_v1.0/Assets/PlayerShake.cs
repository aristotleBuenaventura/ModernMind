using UnityEngine;
using System.Collections;

public class PlayerShake : MonoBehaviour
{
    [Header("Target Player to Shake")]
    public GameObject player;   // assign your player model here

    [Header("Shake Settings")]
    public float duration = 0.3f;   // how long the shake lasts
    public float magnitude = 0.2f;  // how strong the shake is

    private Vector3 originalPos;

    // Call this method when player is hit
    public void Shake()
    {
        if (player != null)
            StartCoroutine(DoShake());
    }

    private IEnumerator DoShake()
    {
        originalPos = player.transform.localPosition;

        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            player.transform.localPosition = originalPos + new Vector3(x, y, 0f);

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Reset position
        player.transform.localPosition = originalPos;
    }
}
