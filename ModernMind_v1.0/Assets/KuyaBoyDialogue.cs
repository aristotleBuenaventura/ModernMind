using UnityEngine;

public class KuyaBoyDialogue : MonoBehaviour
{
    public GameObject dialogue, circle, check;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogue.SetActive(true);
            check.SetActive(true);
            circle.SetActive(false);
        }
    }
}
