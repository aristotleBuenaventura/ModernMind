using UnityEngine;

public class DeathArea : MonoBehaviour
{
    public GameObject cube; // The target position to teleport the player to
    public LifeManager life;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            life.DecreaseLife();
            other.transform.position = cube.transform.position;
        }
    }
}
