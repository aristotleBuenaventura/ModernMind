using UnityEngine;

public class BoxOpener : MonoBehaviour
{
    private bool isOpen = false;

    public void OpenBox()
    {
        if (isOpen) return; // already opened
        isOpen = true;

        Debug.Log($"{gameObject.name} opened!");
        // TODO: play animation, disable collider, etc.
    }

    public void ResetBox()
    {
        isOpen = false;
        Debug.Log($"{gameObject.name} reset!");
        // TODO: reset animation/close the box
    }

    public bool IsOpen => isOpen;
}
