using UnityEngine;

public class ShowPuzzle : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject canvas;
    public GameObject[] buttons;   // ✅ Array instead of button1, button2, button3

    [Header("Puzzle Objects")]
    public GameObject[] puzzles;   // ✅ Array instead of Puzzle1, Puzzle2, Puzzle3

    [Header("Player Animator")]
    public PlayerAnimator animator;

    /// <summary>
    /// Shows a puzzle by index (0 = Puzzle1, 1 = Puzzle2, 2 = Puzzle3, etc.)
    /// </summary>
    public void ShowPuzzleByIndex(int index)
    {
        if (index < 0 || index >= puzzles.Length)
        {
            Debug.LogError($"❌ Invalid puzzle index: {index}");
            return;
        }

        // Hide canvas
        if (canvas != null) canvas.SetActive(false);

        // Disable only the clicked button
        if (buttons != null && index < buttons.Length && buttons[index] != null)
            buttons[index].SetActive(false);

        // Activate the correct puzzle, deactivate others
        for (int i = 0; i < puzzles.Length; i++)
        {
            if (puzzles[i] != null)
                puzzles[i].SetActive(i == index);
        }

        // Set carry animation
        if (animator != null)
            animator.isCarry = true;
    }
}
