using UnityEngine;

public class BoxQuestion : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (QuestionManager.Instance != null)
            {
                // 👉 subscribe temporary lang para dito sa box
                QuestionManager.Instance.OnAnswered += HandleAnswer;
                QuestionManager.Instance.StartQuestions();
            }
            else
            {
                Debug.LogWarning("⚠️ Walang QuestionManager sa scene!");
            }
        }
    }

    void HandleAnswer(bool isCorrect)
    {
        if (isCorrect)
        {
            Debug.Log("done");
            gameObject.SetActive(false); // hide this specific box
        }

        // 👉 unsubscribe agad para hindi maapektuhan ang ibang box
        if (QuestionManager.Instance != null)
            QuestionManager.Instance.OnAnswered -= HandleAnswer;
    }
}
