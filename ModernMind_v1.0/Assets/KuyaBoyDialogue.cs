using UnityEngine;

public class KuyaBoyDialogue : MonoBehaviour
{
    public GameObject dialogue, circle;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogue.SetActive(true);
            circle.SetActive(false);
        }
    }
}
