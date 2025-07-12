using UnityEngine;

public class TrashLogic : MonoBehaviour
{
    public TrashResultClose result;
    public ShowUI bag;
    public GameObject BurgerParent, LibroParent, CupParent, BlueButton, GreenButton, BlackButton, check, circles;
    public ShowUI task;
    private bool blueDone = false;
    private bool greenDone = false;
    private bool blackDone = false;

    private void CheckAllDone()
    {
        if (blueDone && greenDone && blackDone)
        {
            Debug.Log("ALLDONE");
            result.ResultClose();
            bag.UICanvasClose();
            task.UICanvasShow();
            check.SetActive(true);
            circles.SetActive(false);


        }
    }

    public void blueLogic()
    {
        string savedValue = PlayerPrefs.GetString("CheckerValue");
        bag.UICanvasClose();

        if (savedValue == "blue")
        {
            result.TumpakShow();
            BlueButton.SetActive(false);
            LibroParent.SetActive(false);
            blueDone = true;
            CheckAllDone();
        }
        else
        {
            result.MaliShow();
        }
    }

    public void greenLogic()
    {
        string savedValue = PlayerPrefs.GetString("CheckerValue");
        bag.UICanvasClose();

        if (savedValue == "green")
        {
            result.TumpakShow();
            GreenButton.SetActive(false);
            BurgerParent.SetActive(false);
            greenDone = true;
            CheckAllDone();
        }
        else
        {
            result.MaliShow();
        }
    }

    public void blackLogic()
    {
        string savedValue = PlayerPrefs.GetString("CheckerValue");
        bag.UICanvasClose();

        if (savedValue == "black")
        {
            result.TumpakShow();
            BlackButton.SetActive(false);
            CupParent.SetActive(false);
            blackDone = true;
            CheckAllDone();
        }
        else
        {
            result.MaliShow();
        }
    }
}
