using UnityEngine;

public class Scene2CanvasManager : MonoBehaviour
{
    public GameObject loading, FirstCanvas, SecondCanvas, ThirdCanvas, Loading2Canvas, FourthCanvas, FifthCanvas, SixthCanvas, SeventhCanvas, EighthCanvas, NinthCanvas, TenthCanvas, EleventhCanvas, TwelfthCanvas, ThirteenthCanvas;
    public ShowUI taskCanvas;
    public GameObject unboxShip;
    public TimerDisplay timer;

    void Start()
    {
        loading.SetActive(true);
        FirstCanvas.SetActive(false);
        SecondCanvas.SetActive(false);
        ThirdCanvas.SetActive(false);
        FourthCanvas.SetActive(false);
        FifthCanvas.SetActive(false);
        SixthCanvas.SetActive(false);
        SeventhCanvas.SetActive(false);
        EighthCanvas.SetActive(false);
        NinthCanvas.SetActive(false);
        TenthCanvas.SetActive(false);
        EleventhCanvas.SetActive(false);
        TwelfthCanvas.SetActive(false);
        ThirteenthCanvas.SetActive(false);
        Loading2Canvas.SetActive(false);
        unboxShip.SetActive(false);
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

    public void Loading2Show()
    {
        ShowDialogue(Loading2Canvas);
    }

    public void FourthCanvasShow()
    {
        ShowDialogue(FourthCanvas);
    }

    public void FifthCanvasShow()
    {
        ShowDialogue(FifthCanvas);
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

    public void TenthCanvasShow()
    {
        ShowDialogue(TenthCanvas);
    }

    public void EleventhCanvasShow()
    {
        ShowDialogue(EleventhCanvas);
    }

    public void TwelfthCanvasShow()
    {
        ShowDialogue(TwelfthCanvas);
    }

    public void ThirteenthCanvasShow()
    {
        ShowDialogue(ThirteenthCanvas);
    }

    public void ThirteenthCanvasClose()
    {
        ThirteenthCanvas.SetActive(false);
        taskCanvas.UICanvasShow();
        unboxShip.SetActive(true);
        timer.StartTimer();
    }

    private void ShowDialogue(GameObject dialogue)
    {
        loading.SetActive(false);
        FirstCanvas.SetActive(false);
        SecondCanvas.SetActive(false);
        ThirdCanvas.SetActive(false);
        Loading2Canvas.SetActive(false);
        FourthCanvas.SetActive(false);
        FifthCanvas.SetActive(false);
        SixthCanvas.SetActive(false);
        SeventhCanvas.SetActive(false);
        EighthCanvas.SetActive(false);
        NinthCanvas.SetActive(false);
        TenthCanvas.SetActive(false);
        EleventhCanvas.SetActive(false);
        TwelfthCanvas.SetActive(false);
        ThirteenthCanvas.SetActive(false);

        dialogue.SetActive(true);
    }
}
