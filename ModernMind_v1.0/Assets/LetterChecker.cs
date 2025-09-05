using UnityEngine;

public class LetterChecker : MonoBehaviour
{
    public string letterValue;
    public GameObject BagCanvas, BagIcon, ButtonUi;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetString("LetterValue", letterValue);
            PlayerPrefs.Save(); // Optional, ensures data is written immediately
            Debug.Log("Saved LetterValue: " + PlayerPrefs.GetString("LetterValue"));
            BagCanvas.SetActive(true);
            BagIcon.SetActive(false);
            ButtonUi.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BagCanvas.SetActive(false);
            BagIcon.SetActive(true);
            ButtonUi.SetActive(false);
        }
    }
}
