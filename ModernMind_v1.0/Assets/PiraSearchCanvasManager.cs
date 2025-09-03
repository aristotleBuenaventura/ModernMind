using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PiraSearchCanvasManager : MonoBehaviour
{
    public GameObject Loading, FirstCanvas, SecondCanvas, ThirdCanvas, FourthCanvas, FifthCanvas, SixthCanvas, SeventhCanvas, EighthCanvas;
    
    void Start()
    {
        LoadingShow();
        FirstCanvas.SetActive(false);
        SecondCanvas.SetActive(false);
        ThirdCanvas.SetActive(false);
        FourthCanvas.SetActive(false);
        FifthCanvas.SetActive(false);
        SixthCanvas.SetActive(false);
        SeventhCanvas.SetActive(false);
        EighthCanvas.SetActive(false);
    }

    public void LoadingShow()
    {
        ShowDialogue(Loading);
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

    public void EighthCanvasClose()
    {
        EighthCanvas.SetActive(false);
    }

    private void ShowDialogue(GameObject dialogue)
    {
        Loading.SetActive(false);
        FirstCanvas.SetActive(false);
        SecondCanvas.SetActive(false);
        ThirdCanvas.SetActive(false);
        FourthCanvas.SetActive(false);
        FifthCanvas.SetActive(false);
        SixthCanvas.SetActive(false);
        SeventhCanvas.SetActive(false);
        EighthCanvas.SetActive(false);
        dialogue.SetActive(true);
    }
}
