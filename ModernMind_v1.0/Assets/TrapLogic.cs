using UnityEngine;
using System.Collections;

public class TrapLogic : MonoBehaviour
{
    private bool canCollide = true; // flag to control collision cooldown
    public float cooldownTime = 2f; // seconds delay
    public PlayerShake shake;
    public TimerDisplay time;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canCollide)
        {
            Debug.Log("Detected");
            shake.Shake();
            time.DecreaseTime(20f);
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
