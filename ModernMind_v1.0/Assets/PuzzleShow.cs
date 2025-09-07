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
    [SerializeField] private bool isDone = false; // ✅ locked only when correct puzzle is placed

    // Public getter (read-only)
    public bool IsEmpty => isEmpty;
    public bool IsDone => isDone;

    private void OnTriggerEnter(Collider other)
    {
        if (isDone) return; // stop if correct puzzle already placed

        // --- correct puzzle ---
        if (other.CompareTag(correctTag))
        {
            // ✅ Always allow correct puzzle if slot not permanently done
            HandlePuzzle(correctPuzzle, correctPuzzleOnHand, true);

            // Hide any wrong puzzles still visible
            if (wrongPuzzles != null)
            {
                foreach (var w in wrongPuzzles)
                {
                    if (w != null) w.SetActive(false);
                }
            }

            return;
        }

        // --- wrong puzzle (only if slot is currently empty) ---
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
        else
        {
            Debug.Log($"[PuzzleShow] Blocked placement: Slot already has something (isEmpty={isEmpty}, isDone={isDone}).");
        }
    }

    private void HandlePuzzle(GameObject puzzleObj, GameObject handObj, bool correct)
    {
        if (animator != null) animator.SetCarry(false);

        isEmpty = false;

        if (correct)
            isDone = true; // ✅ only lock if correct

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
        isEmpty = value;
        Debug.Log($"[PuzzleShow] Slot '{gameObject.name}' SetEmpty({value})");
    }
}
