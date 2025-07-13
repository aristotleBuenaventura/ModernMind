using UnityEngine;

public class ShowQuestion : MonoBehaviour
{
    public GameObject PlayerCube, cube;
    public GameObject question, choice1, choice2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerCube.transform.position = cube.transform.position;
            question.SetActive(true);
            choice1.SetActive(true);
            choice2.SetActive(true);
        }
    }
}
