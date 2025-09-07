using UnityEngine;

public class PuzzleShow : MonoBehaviour
{
    [Header("Correct Puzzle")]
    public GameObject correctPuzzle;
    public GameObject correctPuzzleOnHand;
    public GameObject circle;

    [Header("Wrong Puzzles")]
    public GameObject[] wrongPuzzles;
    public GameObject[] wrongPuzzlesOnHand;

    [Header("Tags")]
    public string correctTag;
    public string[] wrongTags;

    [Header("References")]
    public PlayerAnimator animator;

    [Header("States (read-only)")]
    [SerializeField] private bool isEmpty = true; // ✅ private, only modifiable internally
    [SerializeField] private bool isDone = false; // ✅ locked when puzzle is placed

    // Public getter (read-only)
    public bool IsEmpty => isEmpty;
    public bool IsDone => isDone;

    private void OnTriggerEnter(Collider other)
    {
        if (isDone) return; // ✅ Already filled, ignore new entries

        // ✅ Correct puzzle
        if (other.CompareTag(correctTag) && isEmpty)
        {
            HandlePuzzle(correctPuzzle, correctPuzzleOnHand, true);
            return;
        }

        // ✅ Wrong puzzles
        if (isEmpty && wrongTags != null)
        {
            for (int i = 0; i < wrongTags.Length; i++)
            {
                if (other.CompareTag(wrongTags[i]))
                {
                    GameObject wrongPuzzle = (i < wrongPuzzles.Length) ? wrongPuzzles[i] : null;
                    GameObject wrongOnHand = (i < wrongPuzzlesOnHand.Length) ? wrongPuzzlesOnHand[i] : null;

                    HandlePuzzle(wrongPuzzle, wrongOnHand, false);
                    break;
                }
            }
        }
    }

    private void HandlePuzzle(GameObject puzzleObj, GameObject handObj, bool correct)
    {
        animator.SetCarry(false);
        isEmpty = false;
        isDone = true; // ✅ lock slot after any piece is placed

        // Show puzzle on board
        if (puzzleObj != null) puzzleObj.SetActive(true);

        // Show circle indicator
        if (circle != null) circle.SetActive(true);

        // Hide puzzle in hand
        if (handObj != null) handObj.SetActive(false);

        Debug.Log($"📌 Puzzle placed: {puzzleObj?.name ?? "NULL"} | Correct: {correct}");
    }

    // ✅ Setter method for controlled access
    public void SetEmpty(bool value)
    {
        if (!isDone) // only allow if puzzle slot not permanently locked
        {
            isEmpty = value;
            Debug.Log($"⚡ PuzzleShow: isEmpty manually set to {value}");
        }
        else
        {
            Debug.LogWarning("⚠️ Cannot change isEmpty: Puzzle already completed!");
        }
    }
}
