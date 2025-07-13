using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Scene1CanvasManager : MonoBehaviour
{
    public GameObject FirstCanvas, SecondCanvas, ThirdCanvas, ForthCanvas, FifthCanvas, SixthCanvas, SeventhCanvas, EighthCanvas, NinthCanvas;
    public GameObject TenthCanvas, EleventhCanvas, TwelfthCanvas, ThirteenthCanvas, FourteenthCanvas, FifteenthCanvas, SixteenthCanvas, SeventeenthCanvas;
    public GameObject FirstCamera, JoseCamera, Controller, TaskButton, TaskArrow, TrashCircles, MilesCamera;

    void Start()
    {
        FirstCanvasShow();
        TrashCircles.SetActive(false);
        TaskButton.SetActive(false);
        TaskArrow.SetActive(false);
        Controller.SetActive(false);
        FirstCamera.SetActive(true);
        JoseCamera.SetActive(false);
        SecondCanvas.SetActive(false);
        ThirdCanvas.SetActive(false);
        ForthCanvas.SetActive(false);
        FifthCanvas.SetActive(false);
        SixthCanvas.SetActive(false);
        SeventhCanvas.SetActive(false);
        EighthCanvas.SetActive(false);
        NinthCanvas.SetActive(false);

        TenthCanvas.SetActive(false);
        EleventhCanvas.SetActive(false);
        TwelfthCanvas.SetActive(false);
        ThirteenthCanvas.SetActive(false);
        FourteenthCanvas.SetActive(false);
        FifteenthCanvas.SetActive(false);
        SixteenthCanvas.SetActive(false);
        SeventeenthCanvas.SetActive(false);
    }

    public void FirstCanvasShow()
    {
        ShowDialogue(FirstCanvas);
    }

    public void SecondCanvasShow()
    {
        ShowDialogue(SecondCanvas);
    }

    public void ThirdCanvasShow()
    {
        ShowDialogue(ThirdCanvas);
    }

    public void ForthCanvasShow()
    {
        ShowDialogue(ForthCanvas);
    }

    public void FifthCanvasShow()
    {
        ShowDialogue(FifthCanvas);
        FirstCamera.SetActive(false);
        JoseCamera.SetActive(true);
        Controller.SetActive(true);
    }

    public void FifthCanvasClose()
    {
        FifthCanvas.SetActive(false);
        TaskButton.SetActive(true);
        TaskArrow.SetActive(true);
    }

    public void SixthCanvasShow()
    {
        ShowDialogue(SixthCanvas);
    }

    public void SeventhCanvasShow()
    {
        ShowDialogue(SeventhCanvas);
    }

    public void EighthCanvasShow()
    {
        ShowDialogue(EighthCanvas);
    }

    public void NinthCanvasShow()
    {
        ShowDialogue(NinthCanvas);
    }

    public void NinthCanvasClose()
    {
        NinthCanvas.SetActive(false);
        TrashCircles.SetActive(true);
    }

    public void TenthCanvasShow()
    {
        ShowDialogue(TenthCanvas);
        JoseCamera.SetActive(false);
        MilesCamera.SetActive(true);
        Controller.SetActive(false);
    }

    public void EleventhCanvasShow()
    {
        ShowDialogue(EleventhCanvas);
    }

    public void TwelfthCanvasShow()
    {
        ShowDialogue(TwelfthCanvas);
        MilesCamera.SetActive(false);
        FirstCamera.SetActive(true);
    }

    public void ThirteenthCanvasShow()
    {
        ShowDialogue(ThirteenthCanvas);
        MilesCamera.SetActive(true);
        FirstCamera.SetActive(false);
    }

    public void FourteenthCanvasShow()
    {
        ShowDialogue(FourteenthCanvas);
        MilesCamera.SetActive(false);
        JoseCamera.SetActive(true);
    }

    public void FifteenthCanvasShow()
    {
        ShowDialogue(FifteenthCanvas);
    }

    public void SixteenthCanvasShow()
    {
        ShowDialogue(SixteenthCanvas);
    }

    public void SeventeenthCanvasShow()
    {
        ShowDialogue(SeventeenthCanvas);
    }

    private void ShowDialogue(GameObject dialogue)
    {
        FirstCanvas.SetActive(false);
        SecondCanvas.SetActive(false);
        ThirdCanvas.SetActive(false);
        ForthCanvas.SetActive(false);
        FifthCanvas.SetActive(false);
        SixthCanvas.SetActive(false);
        SeventhCanvas.SetActive(false);
        EighthCanvas.SetActive(false);
        NinthCanvas.SetActive(false);
        TenthCanvas.SetActive(false);
        EleventhCanvas.SetActive(false);
        TwelfthCanvas.SetActive(false);
        ThirteenthCanvas.SetActive(false);
        FourteenthCanvas.SetActive(false);
        FifteenthCanvas.SetActive(false);
        SixteenthCanvas.SetActive(false);
        SeventeenthCanvas.SetActive(false);
        dialogue.SetActive(true);
    }
}
