using UnityEngine;

public class ProductMazeChecker : MonoBehaviour
{
    public string productMazeCheckerValue;
    public SetAllButtons Buttons;
    public ShowUI Bag;
    public GameObject powerups;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetString("productMazeCheckerValue", productMazeCheckerValue);
            PlayerPrefs.Save(); // Optional, ensures data is written immediately
            Debug.Log("Saved productMazeCheckerValue: " + PlayerPrefs.GetString("productMazeCheckerValue"));

            Bag.UICanvasShow();
            powerups.SetActive(false);
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
