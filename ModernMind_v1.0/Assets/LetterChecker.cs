using UnityEngine;

public class LetterChecker : MonoBehaviour
{
    public string letterValue;
    public GameObject BagCanvas, BagIcon;
    public SetAllButtons allButtons;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetString("LetterValue", letterValue);
            PlayerPrefs.Save(); // Ensures data is written immediately
            Debug.Log("Saved LetterValue: " + PlayerPrefs.GetString("LetterValue"));

            BagCanvas.SetActive(true);
            allButtons.SetAllButtonsActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BagCanvas.SetActive(false);
            BagIcon.SetActive(true);
            allButtons.SetAllButtonsActive(false);
        }
    }

    
}
