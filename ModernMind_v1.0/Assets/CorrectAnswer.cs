using UnityEngine;

public class CorrectAnswer : MonoBehaviour
{
    public GameObject PlayerCube, cube;
    public GameObject canvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerCube.transform.position = cube.transform.position;
            canvas.SetActive(true);
        }
    }
}
