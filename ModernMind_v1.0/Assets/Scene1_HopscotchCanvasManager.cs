using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Scene1_HopscotchCanvasManager : MonoBehaviour
{

    public GameObject FirstCanvas, SecondCanvas, ThirdCanvas, controls;
    public TimerHopscotch timer;

    void Start()
    {
        FirstCanvasShow();
        SecondCanvas.SetActive(false);
        ThirdCanvas.SetActive(false);
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

        dialogue.SetActive(true);
    }



}
