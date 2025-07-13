using UnityEngine;

public class WrongAnswer : MonoBehaviour
{
    public GameObject platform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            platform.SetActive(false);

        }
    }
}
