using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class QuestionManager : MonoBehaviour
{
    [System.Serializable]
    public class Question
    {
        [TextArea] public string questionText;
        public string optionA;
        public string optionB;
        public int correctAnswer; // 0 = A, 1 = B
    }

    [Header("Questions Setup")]
    public Question[] questions;

    [Header("UI References")]
    public GameObject questionPanel;
    public TextMeshProUGUI questionText;
    public Button buttonA;
    public Button buttonB;
    public TextMeshProUGUI buttonAText;
    public TextMeshProUGUI buttonBText;
    public FisherYatesAlgorithm algo;

    private int currentIndex = 0;

    public static QuestionManager Instance;

    // 👉 Event para ma-notify si BoxQuestion
    public event Action<bool> OnAnswered;

    public TimerHopscotch time;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        questionPanel.SetActive(false);

        buttonA.onClick.AddListener(() => HandleAnswer(0));
        buttonB.onClick.AddListener(() => HandleAnswer(1));
    }

    public void StartQuestions()
    {
        if (currentIndex >= questions.Length)
            currentIndex = 0;

        ShowQuestion();
    }

    void ShowQuestion()
    {
        if (questions.Length == 0) return;

        questionPanel.SetActive(true);

        Question q = questions[currentIndex];
        questionText.text = q.questionText;
        buttonAText.text = q.optionA;
        buttonBText.text = q.optionB;
    }

    bool Answer(int choice)
    {
        Question q = questions[currentIndex];
        bool isCorrect = (choice == q.correctAnswer);

        if (isCorrect)
        {
            algo.ShuffleObjects();
            questionPanel.SetActive(false);
            currentIndex++;
        }
        else
        {
            time.DecreaseTime(10f);
            algo.ShuffleObjects();
            currentIndex++;

            if (currentIndex >= questions.Length)
                currentIndex = 0;

            ShowQuestion();
        }

        return isCorrect;
    }

    void HandleAnswer(int choice)
    {
        bool result = Answer(choice);

        // 👉 Notify lahat ng listeners (kasama si BoxQuestion)
        OnAnswered?.Invoke(result);
    }
}
