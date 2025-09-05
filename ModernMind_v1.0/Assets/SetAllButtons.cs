using UnityEngine;

public class SetAllButtons : MonoBehaviour
{
    public GameObject[] allButtons;

    public void SetAllButtonsActive(bool state)
    {
        foreach (GameObject button in allButtons)
        {
            if (button != null)
                button.SetActive(state);
        }
    }
}
