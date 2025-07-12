using UnityEngine;

public class TrashChecker : MonoBehaviour
{
    public string checkerValue;
    public GameObject OpenLid, CloseLid, Buttons;
    public ShowUI Bag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetString("CheckerValue", checkerValue);
            PlayerPrefs.Save(); // Optional, ensures data is written immediately
            Debug.Log("Saved CheckerValue: " + PlayerPrefs.GetString("CheckerValue"));

            Bag.UICanvasShow();
            CloseLid.SetActive(false);
            OpenLid.SetActive(true);
            Buttons.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Bag.UICanvasClose();
            CloseLid.SetActive(true);
            OpenLid.SetActive(false);
            Buttons.SetActive(false);
        }
    }
}
