using UnityEngine;

public class ShowStore : MonoBehaviour
{
    public GameObject store;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            store.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            store.SetActive(false);
        }
    }
}
