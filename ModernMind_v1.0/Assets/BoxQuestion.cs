using UnityEngine;

public class BoxQuestion : MonoBehaviour
{
    public GameObject box;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            QuestionManager.Instance.StartQuestions();
        }
    }
}
