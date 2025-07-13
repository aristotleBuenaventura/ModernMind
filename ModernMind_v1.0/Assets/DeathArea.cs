using UnityEngine;

public class DeathArea : MonoBehaviour
{
    public GameObject cube; // The target position to teleport the player to

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = cube.transform.position;
        }
    }
}
