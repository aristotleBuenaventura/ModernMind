using UnityEngine;

public class PickUpWrongPiece : MonoBehaviour
{
    public GameObject wrongPiece, wrongPieceOnHand;
    public PuzzleShow puzzleBool;
    public PlayerAnimator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RightHand"))
        {
            wrongPiece.SetActive(false);
            wrongPieceOnHand.SetActive(true);
            puzzleBool.SetEmpty(false);
            animator.SetCarry(true);
        }
    }
}
