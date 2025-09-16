using UnityEngine;

public class AtlasShowPagusapan : MonoBehaviour
{
    public GameObject imageButton, imageDialogue, atlasSelection;

    public void showImageDialogue()
    {
        imageDialogue.SetActive(true);
        imageButton.SetActive(false);
        atlasSelection.SetActive(false);
    }
}
