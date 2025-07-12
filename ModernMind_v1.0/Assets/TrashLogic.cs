using UnityEngine;

public class TrashLogic : MonoBehaviour
{
    public TrashResultClose result;
    public ShowUI bag;
    public GameObject BurgerParent, LibroParent, CupParent, BlueButton, GreenButton, BlackButton;

    public void blueLogic()
    {
        string savedValue = PlayerPrefs.GetString("CheckerValue");
        bag.UICanvasClose();
        
        if (savedValue == "blue")
        {
            result.TumpakShow();
            BlueButton.SetActive(false);
            LibroParent.SetActive(false);
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
        }
        else
        {
            result.MaliShow();
        }
    }

}
