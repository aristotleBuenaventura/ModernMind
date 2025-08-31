using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneGabayManager : MonoBehaviour
{

    public GameObject FirstCanvas, SecondCanvas, ThirdCanvas, ForthCanvas, FifthCanvas, SixthCanvas, SeventhCanvas;

    void Start()
    {
        FirstCanvasShow();
        SecondCanvas.SetActive(false);
        ThirdCanvas.SetActive(false);
        ForthCanvas.SetActive(false);
        FifthCanvas.SetActive(false);
        SixthCanvas.SetActive(false);
        SeventhCanvas.SetActive(false);

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
    }

    public void SixthCanvasShow()
    {
        ShowDialogue(SixthCanvas);
    }

    public void SeventhCanvasShow()
    {
        ShowDialogue(SeventhCanvas);
    }

    public void SeventhCanvasClose()
    {
        SeventhCanvas.SetActive(false);
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
        dialogue.SetActive(true);
    }



}
