using UnityEngine;
using UnityEngine.UI; // Needed for Image

public class BagButtonColors : MonoBehaviour
{
    public GameObject trashButton, powerButton;

    public void Trash()
    {
        Image btnImage1 = trashButton.GetComponent<Image>();
        Image btnImage2 = powerButton.GetComponent<Image>();

        if (btnImage1 != null && btnImage2 != null)
        {
            btnImage1.color = Color.green;  
            btnImage2.color = Color.white;  
        }
    }

    public void PowerUps()
    {
        Image btnImage1 = trashButton.GetComponent<Image>();
        Image btnImage2 = powerButton.GetComponent<Image>();

        if (btnImage1 != null && btnImage2 != null)
        {
            btnImage2.color = Color.green;  
            btnImage1.color = Color.white;  
        }
    }
}
