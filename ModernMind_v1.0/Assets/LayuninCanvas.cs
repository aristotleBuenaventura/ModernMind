using UnityEngine;

public class LayuninCanvas : MonoBehaviour
{
    public GameObject LayuninX, LayuninNext, MahusayX, MahusayCanvas, LayuninCanvasUI, check;
    public ShowUI task;

    public void LayuninCanvasShow()
    {
        task.UICanvasShow();
        LayuninX.SetActive(false);
        LayuninNext.SetActive(true);
        check.SetActive(true);
    }

    public void MahusayCanvasShow()
    {
        MahusayCanvas.SetActive(true);
        LayuninCanvasUI.SetActive(false);
    }

    public void MahusayCanvasClose()
    {
        MahusayCanvas.SetActive(false);
        LayuninX.SetActive(true);
        LayuninNext.SetActive(false);
        LayuninCanvasUI.SetActive(true);
        task.UICanvasClose();
    }
}
