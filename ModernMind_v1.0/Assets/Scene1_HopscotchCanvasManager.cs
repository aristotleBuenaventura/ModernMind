using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Scene1_HopscotchCanvasManager : MonoBehaviour
{

    public GameObject FirstCanvas, SecondCanvas, ThirdCanvas, FourthCanvas, FifthCanvas, SixthCanvas, SeventhCanvas, EighthCanvas, controls;
    public TimerHopscotch timer;

    void Start()
    {
        FirstCanvasShow();
        SecondCanvas.SetActive(false);
        ThirdCanvas.SetActive(false);
        FourthCanvas.SetActive(false);
        FifthCanvas.SetActive(false);
        SixthCanvas.SetActive(false);
        SeventhCanvas.SetActive(false);
        EighthCanvas.SetActive(false);
        controls.SetActive(false);
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

    public void ThirdCanvasClose()
    {
        ThirdCanvas.SetActive(false);
        controls.SetActive(true);
        timer.StartTimer();
    }

    private void ShowDialogue(GameObject dialogue)
    {
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
