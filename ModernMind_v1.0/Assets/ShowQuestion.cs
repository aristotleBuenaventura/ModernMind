using UnityEngine;

public class ShowQuestion : MonoBehaviour
{
    public GameObject PlayerCube, cube;
    public GameObject question;
    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true;

            PlayerCube.transform.position = cube.transform.position;
            question.SetActive(true);

        }
    }
}
