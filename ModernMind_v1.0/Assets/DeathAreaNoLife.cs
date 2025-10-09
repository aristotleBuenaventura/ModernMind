using UnityEngine;

public class DeathAreaNoLife : MonoBehaviour
{
    public GameObject cube; // The target position to teleport the player to
    public LifeManager2 life;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            life.DecreaseLife();
            other.transform.position = cube.transform.position;
        }
    }
}
