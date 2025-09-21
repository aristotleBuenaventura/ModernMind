using UnityEngine;

public class Scene2MazeCanvasManager : MonoBehaviour
{
    public GameObject Loading, Atlas1, Atlas2, Atlas3, Atlas4, First, Second, Third, Fourth, Fifth, Sixth, Atlas5;
    public GameObject Fence;
    public TimerDisplay time;

    void Start()
    {
        LoadingCanvasShow();
        Atlas1.SetActive(false);
        Atlas2.SetActive(false);
        Atlas3.SetActive(false);
        Atlas4.SetActive(false);
        First.SetActive(false);
        Second.SetActive(false);
        Third.SetActive(false);
        Fourth.SetActive(false);
        Fifth.SetActive(false);
        Sixth.SetActive(false);
        Atlas5.SetActive(false);
        Fence.SetActive(true);
    }

    public void LoadingCanvasShow()
    {
        ShowDialogue(Loading);
    }

    public void Atlas1CanvasShow()
    {
        ShowDialogue(Atlas1);
    }

    public void Atlas2CanvasShow()
    {
        ShowDialogue(Atlas2);
    }

    public void Atlas3CanvasShow()
    {
        ShowDialogue(Atlas3);
    }

    public void Atlas4CanvasShow()
    {
        ShowDialogue(Atlas4);
    }

    public void FirstCanvasShow()
    {
        ShowDialogue(First);
    }

    public void SecondCanvasShow()
    {
        ShowDialogue(Second);
    }

    public void ThirdCanvasShow()
    {
        ShowDialogue(Third);
    }

    public void FourthCanvasShow()
    {
        ShowDialogue(Fourth);
    }

    public void FifthCanvasShow()
    {
        ShowDialogue(Fifth);
    }

    public void SixthCanvasShow()
    {
        ShowDialogue(Sixth);
    }

    public void Atlas5CanvasShow()
    {
        ShowDialogue(Atlas5);
    }

    public void Atlas5CanvasClose()
    {
        Atlas5.SetActive(false);
        Fence.SetActive(false);
        time.StartTimer();
    }



    private void ShowDialogue(GameObject dialogue)
    {
        Loading.SetActive(false);
        Atlas1.SetActive(false);
        Atlas2.SetActive(false);
        Atlas3.SetActive(false);
        Atlas4.SetActive(false);
        First.SetActive(false);
        Second.SetActive(false);
        Third.SetActive(false);
        Fourth.SetActive(false);
        Fifth.SetActive(false);
        Sixth.SetActive(false);
        Atlas5.SetActive(false);

        dialogue.SetActive(true);
    }

}
