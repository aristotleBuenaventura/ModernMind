using UnityEngine;

public class BoxQuestion : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            QuestionManager.Instance.StartQuestions();
        }
    }
}
