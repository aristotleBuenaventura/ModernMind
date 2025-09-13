using UnityEngine;

public class ProductChecker : MonoBehaviour
{
    public string productCheckerValue;
    public SetAllButtons Buttons;
    public ShowUI Bag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetString("productCheckerValue", productCheckerValue);
            PlayerPrefs.Save(); // Optional, ensures data is written immediately
            Debug.Log("Saved productCheckerValue: " + PlayerPrefs.GetString("productCheckerValue"));

            Bag.UICanvasShow();
            Buttons.SetAllButtonsActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Bag.UICanvasClose();
            Buttons.SetAllButtonsActive(false);
        }
    }
}
