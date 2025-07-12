using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Scene1CanvasManager : MonoBehaviour
{
    public GameObject FirstCanvas, SecondCanvas, ThirdCanvas, ForthCanvas, FifthCanvas;
    public GameObject FirstCamera, JoseCamera, Controller, TaskButton, TaskArrow;

    void Start()
    {
        FirstCanvasShow();
        TaskButton.SetActive(false);
        TaskArrow.SetActive(false);
        Controller.SetActive(false);
        FirstCamera.SetActive(true);
        JoseCamera.SetActive(false);
        SecondCanvas.SetActive(false);
        ThirdCanvas.SetActive(false);
        ForthCanvas.SetActive(false);
        FifthCanvas.SetActive(false);
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

    private void ShowDialogue(GameObject dialogue)
    {
        FirstCanvas.SetActive(false);
        SecondCanvas.SetActive(false);
        ThirdCanvas.SetActive(false);
        ForthCanvas.SetActive(false);
        FifthCanvas.SetActive(false);
        dialogue.SetActive(true);
    }
}