using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Scene1_HopscotchCanvasManager : MonoBehaviour
{

    public GameObject FirstCanvas, SecondCanvas, ThirdCanvas, FourthCanvas, FifthCanvas, SixthCanvas, SeventhCanvas, EighthCanvas, controls, FirstMiles, SecondMiles, ThirdMiles;
    public TimerHopscotch timer;
    public TeleportPosition tp;
    public GameObject Miles1, Miles2, MilesCircle, TaskCanvas, FourthMiles, FifthMiles, map;
    public GameObject Cut1, Cut2;

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
        FirstMiles.SetActive(false);
        SecondMiles.SetActive(false);
        ThirdMiles.SetActive(false);
        FourthMiles.SetActive(false);
        FifthMiles.SetActive(false);
        Cut1.SetActive(false);
        Cut2.SetActive(false);
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
        controls.SetActive(true);
        timer.StartTimer();
    }

    public void FirstMilesShow()
    {
        tp.TeleportToCube();
        ShowDialogue(FirstMiles);
    }

    public void SecondMilesShow()
    {
        ShowDialogue(SecondMiles);
    }

    public void ThirdMilesShow()
    {
        ShowDialogue(ThirdMiles);
    }

    public void Cut1Show()
    {
        ShowDialogue(Cut1);
    }

    public void Cut2Show()
    {
        ShowDialogue(Cut2);
    }

    public void Cut2Close()
    {
        Cut2.SetActive(false);
        Miles1.SetActive(false);
        Miles2.SetActive(true);
        MilesCircle.SetActive(true);
        TaskCanvas.SetActive(true);
        map.SetActive(true);
    }

    public void FourthMilesShow()
    {
        ShowDialogue(FourthMiles);
    }

    public void FifthMilesShow()
    {
        ShowDialogue(FifthMiles);
    }

    public void FifthMilesClose()
    {
        FifthMiles.SetActive(false);
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
        FirstMiles.SetActive(false);
        SecondMiles.SetActive(false);
        ThirdMiles.SetActive(false);
        FourthMiles.SetActive(false);
        FifthMiles.SetActive(false);
        Cut1.SetActive(false);
        Cut2.SetActive(false);
        dialogue.SetActive(true);
    }



}
