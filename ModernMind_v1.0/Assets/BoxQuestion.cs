using UnityEngine;

public class BoxQuestion : MonoBehaviour
{
    private bool isWaitingForCorrect = false;
    public CoinsValue coins;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (QuestionManager.Instance != null)
            {
                // subscribe once lang, habang hindi pa siya nawawala
                if (!isWaitingForCorrect)
                {
                    QuestionManager.Instance.OnAnswered += HandleAnswer;
                    isWaitingForCorrect = true;
                }

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
            //coins.IncrementScore(10);
            gameObject.SetActive(false); // this specific box only

            // ✅ unsubscribe once tama na
            if (QuestionManager.Instance != null)
                QuestionManager.Instance.OnAnswered -= HandleAnswer;

            isWaitingForCorrect = false;
        }
        // ❌ kung mali, hindi mag-a-unsubscribe
        // → hihintay pa rin hanggang tama
    }
}
