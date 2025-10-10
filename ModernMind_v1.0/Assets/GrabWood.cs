using UnityEngine;

public class GrabWood : MonoBehaviour
{
    public GameObject wood;
    public WoodCounter woodCount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            wood.SetActive(false);
            woodCount.Increment();
        }
    }
}
