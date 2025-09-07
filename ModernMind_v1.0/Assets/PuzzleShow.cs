using UnityEngine;
using System.Collections;

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
    [SerializeField] private bool isEmpty = true;
    private bool cooldownActive = false; // ⏳ new flag

    public bool IsEmpty => isEmpty;

    private void OnTriggerEnter(Collider other)
    {
        if (cooldownActive) return; // ⛔ block placement if cooldown is active

        // --- correct puzzle ---
        if (other.CompareTag(correctTag))
        {
            HandlePuzzle(correctPuzzle, correctPuzzleOnHand, true);

            if (wrongPuzzles != null)
            {
                foreach (var w in wrongPuzzles)
                {
                    if (w != null) w.SetActive(false);
                }
            }

            return;
        }

        // --- wrong puzzle (always allowed, but respects cooldown) ---
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

        if (correct)
            isEmpty = false;

        // Show puzzle on board
        if (puzzleObj != null) puzzleObj.SetActive(true);

        // Show circle indicator
        if (circle != null) circle.SetActive(true);

        // Hide puzzle in hand
        if (handObj != null) handObj.SetActive(false);

        Debug.Log($"📌 Puzzle placed: {puzzleObj?.name ?? "NULL"} | Correct: {correct}");

        // Start cooldown so it won't snap immediately again
        StartCoroutine(SnapCooldown(3f));
    }

    private IEnumerator SnapCooldown(float delay)
    {
        cooldownActive = true;
        yield return new WaitForSeconds(delay);
        cooldownActive = false;
    }

    public void SetEmpty(bool value)
    {
        isEmpty = value;
        Debug.Log($"[PuzzleShow] Slot '{gameObject.name}' SetEmpty({value})");
    }
}
