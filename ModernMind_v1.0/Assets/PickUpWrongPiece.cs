using UnityEngine;

public class PickUpWrongPiece : MonoBehaviour
{
    public GameObject wrongPiece;         // Wrong piece on board
    public GameObject wrongPieceOnHand;   // Wrong piece in hand
    public PuzzleShow puzzleBool;
    public PlayerAnimator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RightHand"))
        {
            // Hide wrong piece from board
            wrongPiece.SetActive(false);

            // Show piece in hand again
            wrongPieceOnHand.SetActive(true);

            if (puzzleBool != null)
            {
                puzzleBool.SetEmpty(true); // ✅ Mark slot free again
            }


            // Carry animation
            if (animator != null)
                animator.SetCarry(true);

            Debug.Log($"🖐️ Picked up {wrongPiece.name}, slot freed and can be placed again.");
        }
    }
}
