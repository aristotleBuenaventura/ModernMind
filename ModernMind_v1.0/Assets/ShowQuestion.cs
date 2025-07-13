using UnityEngine;

public class ShowQuestion : MonoBehaviour
{
    public GameObject PlayerCube, cube;
    public GameObject question;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerCube.transform.position = cube.transform.position;
            question.SetActive(true);

        }
    }
}
