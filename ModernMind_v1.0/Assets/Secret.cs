using UnityEngine;

public class Secret : MonoBehaviour
{
    public CoinsValue coins;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            coins.IncrementScore(10000);
        }
    }
}
