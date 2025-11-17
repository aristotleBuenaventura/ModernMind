using UnityEngine;

public class WrongTrash : MonoBehaviour
{
    public GameObject trash, maliUI;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerTrash"))
        {
            trash.SetActive(false);
            maliUI.SetActive(true);
        }
    }
}
