using UnityEngine;
using System.Collections;

public class TrapLogic : MonoBehaviour
{
    private bool canCollide = true; // flag to control collision cooldown
    public float cooldownTime = 2f; // seconds delay
    public CameraShake shake;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canCollide)
        {
            Debug.Log("Detected");
            shake.Shake();
            StartCoroutine(CollisionCooldown());
        }
    }

    private IEnumerator CollisionCooldown()
    {
        canCollide = false;              // disable collision detection
        yield return new WaitForSeconds(cooldownTime); // wait for 2s
        canCollide = true;               // re-enable collision detection
    }
}
