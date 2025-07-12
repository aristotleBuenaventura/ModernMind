using UnityEngine;

public class ShowUI : MonoBehaviour
{
    public GameObject UICanvas, UIButton;

    void Start()
    {
        UIButton.SetActive(true);
        UICanvas.SetActive(false);
    }


    public void UICanvasShow() 
    {
        UIButton.SetActive(false);
        UICanvas.SetActive(true);
    }

    public void UICanvasClose()
    {
        UIButton.SetActive(true);
        UICanvas.SetActive(false);
    }

}
