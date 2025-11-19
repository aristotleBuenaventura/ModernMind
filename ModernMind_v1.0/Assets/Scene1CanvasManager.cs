using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Scene1CanvasManager : MonoBehaviour
{
    public GameObject FirstCanvas, SecondCanvas, ThirdCanvas, ForthCanvas, FifthCanvas, SixthCanvas, SeventhCanvas, EighthCanvas, NinthCanvas, forth_2, forth_3, forth_4, forth_5, forth_6, forth_7, forth_8, loading2;
    public GameObject TenthCanvas, EleventhCanvas, TwelfthCanvas, ThirteenthCanvas, FourteenthCanvas, FifteenthCanvas, SixteenthCanvas, SeventeenthCanvas;
    public GameObject FirstCamera, JoseCamera, Controller, TaskButton, TaskArrow, TrashCircles, MilesCamera, TV , Usok, BoardCamera, loading, skip, DialogueCamera;
    public TeleportPosition teleport;
    public SceneLoader scene;
    public TimerDisplay timer;
    public GameObject Cut1, Cut2, Cut3, Cut4;

    void Start()
    {
        loading.SetActive(true);
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
        forth_2.SetActive(false);
        forth_3.SetActive(false);
        forth_4.SetActive(false);
        forth_5.SetActive(false);
        forth_6.SetActive(false);
        forth_7.SetActive(false);
        forth_8.SetActive(false);
        loading2.SetActive(false);

        TenthCanvas.SetActive(false);
        EleventhCanvas.SetActive(false);
        TwelfthCanvas.SetActive(false);
        ThirteenthCanvas.SetActive(false);
        FourteenthCanvas.SetActive(false);
        FifteenthCanvas.SetActive(false);
        SixteenthCanvas.SetActive(false);
        SeventeenthCanvas.SetActive(false);
        TV.SetActive(false);
        Usok.SetActive(false);
        BoardCamera.SetActive(false);
        skip.SetActive(false);
        Cut1.SetActive(false);
        Cut2.SetActive(false);
        Cut3.SetActive(false);
        Cut4.SetActive(false);
    }
    
    public void Cut1Show()
    {
        ShowDialogue(Cut1);
    }

    public void Cut2Show()
    {
        ShowDialogue(Cut2);
    }

    public void Cut3Show()
    {
        ShowDialogue(Cut3);
    }

    public void Cut4Show()
    {
        ShowDialogue(Cut4);
    }

    public void Cut4Close()
    {
        Cut4.SetActive(false);
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

    public void loading2Show()
    {
        ShowDialogue(loading2);
    }

    public void Forth_2CanvasShow()
    {
        ShowDialogue(forth_2);
    }

    public void Forth_3CanvasShow()
    {
        ShowDialogue(forth_3);
    }

    public void Forth_4CanvasShow()
    {
        ShowDialogue(forth_4);
    }

    public void Forth_5CanvasShow()
    {
        ShowDialogue(forth_5);
    }

    public void Forth_6CanvasShow()
    {
        ShowDialogue(forth_6);
    }

    public void Forth_7CanvasShow()
    {
        ShowDialogue(forth_7);
    }

    public void Forth_8CanvasShow()
    {
        ShowDialogue(forth_8);
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
        timer.StartTimer();
    }

    public void SixthCanvasShow()
    {
        ShowDialogue(SixthCanvas);
    }

    public void SeventhCanvasShow()
    {
        ShowDialogue(SeventhCanvas);
        timer.PauseTimer();
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
        timer.ResumeTimer();
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
        DialogueCamera.SetActive(true);
    }

    public void ThirteenthCanvasShow()
    {
        ShowDialogue(ThirteenthCanvas);
        MilesCamera.SetActive(true);
        DialogueCamera.SetActive(false);
    }

    public void FourteenthCanvasShow()
    {
        ShowDialogue(FourteenthCanvas);
        teleport.TeleportToCube();
        Usok.SetActive(true);
        MilesCamera.SetActive(false);
        JoseCamera.SetActive(true);
    }

    public void FifteenthCanvasShow()
    {
        ShowDialogue(FifteenthCanvas);
        JoseCamera.SetActive(false);
        BoardCamera.SetActive(true);
    }

    public void SixteenthCanvasShow()
    {
        ShowDialogue(SixteenthCanvas);
    }

    public void SixteenthCanvasClose()
    {
        SixteenthCanvas.SetActive(false);
        Usok.SetActive(false);
        TV.SetActive(true);
        skip.SetActive(true);
    }

    public void SeventeenthCanvasShow()
    {
        ShowDialogue(SeventeenthCanvas);
        JoseCamera.SetActive(true);
        BoardCamera.SetActive(false);
    }

    public void SeventeenthCanvasClose()
    {
        SeventeenthCanvas.SetActive(false);
        FirebaseStageUpdater updater = FindObjectOfType<FirebaseStageUpdater>();
        updater.UpdateStage("level1", "stage2", true);
        scene.Scene1_Hopscotch();
    }

    private void ShowDialogue(GameObject dialogue)
    {
        loading.SetActive(false);
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
        forth_2.SetActive(false);
        forth_3.SetActive(false);
        forth_4.SetActive(false);
        forth_5.SetActive(false);
        forth_6.SetActive(false);
        forth_7.SetActive(false);
        forth_8.SetActive(false);
        loading2.SetActive(false);
        Cut1.SetActive(false);
        Cut2.SetActive(false);
        Cut3.SetActive(false);
        Cut4.SetActive(false);
        dialogue.SetActive(true);
    }
}
