using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PiraSearchCanvasManager : MonoBehaviour
{
    public GameObject Loading, FirstCanvas, SecondCanvas, ThirdCanvas, FourthCanvas, FifthCanvas, SixthCanvas, SeventhCanvas, EighthCanvas;
    public GameObject puzzleUiPart1, puzzleUiPart2, puzzleUiPart3, Puzzle3dPart1, Puzzle3dPart2, Puzzle3dPart3;
    public TimerHopscotch timer;
    public GameObject set1MissingLetter, set2MissingLetter, Letters1, Letters2, cameraTop, Letter1UI, Letter2UI, Letters3, Letter3UI, set3MissingLetter;
    public GameObject dummyCamera, cameraReal, dummyCamera2;

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

    public void FirstCanvasShow() => ShowDialogue(FirstCanvas);
    public void SecondCanvasShow() => ShowDialogue(SecondCanvas);
    public void ThirdCanvasShow() => ShowDialogue(ThirdCanvas);
    public void FourthCanvasShow() => ShowDialogue(FourthCanvas);
    public void FifthCanvasShow() => ShowDialogue(FifthCanvas);
    public void SixthCanvasShow() => ShowDialogue(SixthCanvas);
    public void SeventhCanvasShow() => ShowDialogue(SeventhCanvas);
    public void EighthCanvasShow() => ShowDialogue(EighthCanvas);

    public void EighthCanvasClose()
    {
        EighthCanvas.SetActive(false);
        puzzleUiPart1.SetActive(true);
        puzzleUiPart2.SetActive(false);
        Puzzle3dPart1.SetActive(true);
        timer.StartTimer();
    }

    public void MissingLetterPart1Show()
    {
        set1MissingLetter.SetActive(true);
        Letters1.SetActive(true);
        cameraTop.SetActive(false);
        Letter1UI.SetActive(true);
        Puzzle3dPart1.SetActive(false);
    }

    public void PuzzlePart2Show()
    {
        set1MissingLetter.SetActive(false);
        Letters1.SetActive(false);
        cameraTop.SetActive(true);
        Puzzle3dPart2.SetActive(true);
        puzzleUiPart2.SetActive(true);
        puzzleUiPart1.SetActive(false);
        Puzzle3dPart1.SetActive(false);
        cameraReal.transform.position = dummyCamera.transform.position;
        cameraReal.transform.rotation = dummyCamera.transform.rotation;

    }

    public void MissingLetterPart2Show()
    {
        Puzzle3dPart2.SetActive(false);
        set2MissingLetter.SetActive(true);
        Letters2.SetActive(true);
        cameraTop.SetActive(false);
        Letter2UI.SetActive(true);
        Letter1UI.SetActive(false);
    }

    public void PuzzlePart3Show()
    {
        set2MissingLetter.SetActive(false);
        Letters2.SetActive(false);
        cameraTop.SetActive(true);
        Puzzle3dPart3.SetActive(true);
        puzzleUiPart3.SetActive(true);
        puzzleUiPart2.SetActive(false);
        Puzzle3dPart2.SetActive(false);
        cameraReal.transform.position = dummyCamera2.transform.position;
        cameraReal.transform.rotation = dummyCamera2.transform.rotation;

    }

    public void MissingLetterPart3Show()
    {
        Puzzle3dPart3.SetActive(false);
        set3MissingLetter.SetActive(true);
        Letters3.SetActive(true);
        cameraTop.SetActive(false);
        Letter3UI.SetActive(true);
        Letter2UI.SetActive(false);
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
