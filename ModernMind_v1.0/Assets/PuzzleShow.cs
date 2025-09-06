using UnityEngine;

public class PuzzleShow : MonoBehaviour
{

    public GameObject greenPuzzle, puzzle, circle, puzzleOnHand;
    public string tagValue;
    public PlayerAnimator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagValue))
        {
            animator.isCarry = false;
            Debug.Log("Puzzle Put");
            greenPuzzle.SetActive(false);
            puzzle.SetActive(true);
            circle.SetActive(true);
            puzzleOnHand.SetActive(false);
            Debug.Log("done");
        }
    }
}
