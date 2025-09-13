using UnityEngine;

public class BoxManager : MonoBehaviour
{
    public BoxOpener[] boxes; // assign 5 boxes in Inspector
    private bool lockBoxes = false;

    public void TryOpenBox(BoxOpener box)
    {
        if (lockBoxes) return; // blocked until reset

        // Open this box
        box.OpenBox();

        // Lock all others
        lockBoxes = true;
    }

    public void ResetBoxes()
    {
        foreach (var box in boxes)
        {
            box.ResetBox();
        }

        lockBoxes = false;
    }
}
