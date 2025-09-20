using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    private int currentIndex = 0;

    public static QuestionManager Instance; // singleton

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        questionPanel.SetActive(false);

        // Attach listeners
        buttonA.onClick.AddListener(() => Answer(0));
        buttonB.onClick.AddListener(() => Answer(1));
    }

    public void StartQuestions()
    {
        // kapag na-call ulit, next question na agad
        if (currentIndex >= questions.Length)
            currentIndex = 0; // reset kapag naubos

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

    void Answer(int choice)
    {
        Question q = questions[currentIndex];

        if (choice == q.correctAnswer)
        {
            Debug.Log("✅ Tama!");
            questionPanel.SetActive(false);

            // ready na agad for next question sa susunod na StartQuestions() call
            currentIndex++;
        }
        else
        {
            Debug.Log("❌ Mali, next question...");
            currentIndex++;

            if (currentIndex >= questions.Length)
            {
                currentIndex = 0; // reset kapag naubos
            }

            ShowQuestion();
        }
    }
}
