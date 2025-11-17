using UnityEngine;

public class KuyaBoyDialogue : MonoBehaviour
{
    public GameObject dialogue, circle, check, boyArrow, playerArrow;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogue.SetActive(true);
            check.SetActive(true);
            circle.SetActive(false);
            boyArrow.SetActive(false);
            playerArrow.SetActive(false);
        }
    }
}
