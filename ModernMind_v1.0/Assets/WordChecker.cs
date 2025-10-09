using UnityEngine;

public class WordChecker : MonoBehaviour
{
    public string checkerValue;
    public ShowUI Bag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetString("CheckerWordValue", checkerValue);
            PlayerPrefs.Save(); // Optional, ensures data is written immediately
            Debug.Log("Saved CheckerWordValue: " + PlayerPrefs.GetString("CheckerWordValue"));

            Bag.UICanvasShow();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Bag.UICanvasClose();
        }
    }
}
