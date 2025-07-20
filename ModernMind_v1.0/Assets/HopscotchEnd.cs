using UnityEngine;

public class HopscotchEnd : MonoBehaviour
{
    public GameObject Circle, Result;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Result.SetActive(true);
            Circle.SetActive(false);
        }
    }
}
