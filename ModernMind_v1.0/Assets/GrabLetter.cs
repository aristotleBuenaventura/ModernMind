using UnityEngine;

public class GrabLetter : MonoBehaviour
{
    public GameObject Letter3D, Letter2D, LetterButton;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Letter3D.SetActive(false);
            Letter2D.SetActive(true);
            LetterButton.SetActive(true);
        }
    }
}
