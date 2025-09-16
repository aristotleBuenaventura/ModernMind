using UnityEngine;

public class Scene2CanvasManager : MonoBehaviour
{
    public GameObject loading, FirstCanvas, SecondCanvas, ThirdCanvas, Loading2Canvas, FourthCanvas, FifthCanvas, SixthCanvas, SeventhCanvas, EighthCanvas, NinthCanvas, TenthCanvas, EleventhCanvas, TwelfthCanvas, ThirteenthCanvas;
    public ShowUI taskCanvas;
    public GameObject unboxShip;
    public TimerDisplay timer;
    public GameObject C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, atlasSelection, pasaporte, kalakalan, kultura, teknolohiya, migrasyon;

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
        C14.SetActive(false);
        C15.SetActive(false);
        C16.SetActive(false);
        C17.SetActive(false);
        C18.SetActive(false);
        C19.SetActive(false);
        C20.SetActive(false);
        C21.SetActive(false);
        C22.SetActive(false);
        C23.SetActive(false);
        C24.SetActive(false);
        atlasSelection.SetActive(false);
        pasaporte.SetActive(false);
        kalakalan.SetActive(false);
        kultura.SetActive(false);
        teknolohiya.SetActive(false);
        migrasyon.SetActive(false);
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

    public void C14CanvasShow()
    {
        ShowDialogue(C14);
    }

    public void C15CanvasShow()
    {
        ShowDialogue(C15);
    }

    public void C16CanvasShow()
    {
        ShowDialogue(C16);
    }

    public void C17CanvasShow()
    {
        ShowDialogue(C17);
    }

    public void C18CanvasShow()
    {
        ShowDialogue(C18);
    }

    public void C19CanvasShow()
    {
        ShowDialogue(C19);
    }

    public void C20CanvasShow()
    {
        ShowDialogue(C20);
    }

    public void atlasSelectionCanvasShow()
    {
        ShowDialogue(atlasSelection);
    }

    public void C21CanvasShow()
    {
        ShowDialogue(C21);
    }

    public void C22CanvasShow()
    {
        ShowDialogue(C22);
    }

    public void C23CanvasShow()
    {
        ShowDialogue(C23);
    }

    public void C24CanvasShow()
    {
        ShowDialogue(C24);
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
        C14.SetActive(false);
        C15.SetActive(false);
        C16.SetActive(false);
        C17.SetActive(false);
        C18.SetActive(false);
        C19.SetActive(false);
        C20.SetActive(false);
        C21.SetActive(false);
        C22.SetActive(false);
        C23.SetActive(false);
        C24.SetActive(false);
        atlasSelection.SetActive(false);
        pasaporte.SetActive(false);
        kalakalan.SetActive(false);
        kultura.SetActive(false);
        teknolohiya.SetActive(false);
        migrasyon.SetActive(false);
        dialogue.SetActive(true);
    }
}
