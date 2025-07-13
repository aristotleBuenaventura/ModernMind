using UnityEngine;

public class CorrectAnswer : MonoBehaviour
{
    public GameObject PlayerCube, cube;
    public GameObject canvas, choice1, choice2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerCube.transform.position = cube.transform.position;
            canvas.SetActive(true);
        }
    }
}
