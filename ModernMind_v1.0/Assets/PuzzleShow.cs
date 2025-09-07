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
    [SerializeField] private bool isEmpty = true; // ✅ only locks when correct puzzle is placed

    // Public getter (read-only)
    public bool IsEmpty => isEmpty;

    private void OnTriggerEnter(Collider other)
    {
        // --- correct puzzle ---
        if (other.CompareTag(correctTag))
        {
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

        // --- wrong puzzle (always allowed, even if same wrongTag again) ---
        if (wrongTags != null)
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
        if (animator != null) animator.SetCarry(false);

        // lock the slot only if correct
        if (correct)
            isEmpty = false;

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
