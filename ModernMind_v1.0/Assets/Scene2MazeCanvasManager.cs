using UnityEngine;

public class Scene2MazeCanvasManager : MonoBehaviour
{
    public GameObject Loading, Atlas1, Atlas2, Atlas3, Atlas4, First, Second, Third, Fourth, Fifth, Sixth, Atlas5;
    public GameObject Fence, Atlas6, Atlas7, Atlas8, Atlas9, Atlas10, Atlas11, Atlas12;
    public TimerHopscotch time;

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
        Atlas6.SetActive(false);
        Atlas7.SetActive(false);
        Atlas8.SetActive(false);
        Atlas9.SetActive(false);
        Atlas10.SetActive(false);
        Atlas11.SetActive(false);
        Atlas12.SetActive(false);
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

    public void Atlas6CanvasShow()
    {
        ShowDialogue(Atlas6);
    }

    public void Atlas7CanvasShow()
    {
        ShowDialogue(Atlas7);
    }

    public void Atlas8CanvasShow()
    {
        ShowDialogue(Atlas8);
    }

    public void Atlas9CanvasShow()
    {
        ShowDialogue(Atlas9);
    }

    public void Atlas10CanvasShow()
    {
        ShowDialogue(Atlas10);
    }

    public void Atlas11CanvasShow()
    {
        ShowDialogue(Atlas11);
    }

    public void Atlas12CanvasShow()
    {
        ShowDialogue(Atlas12);
    }

    public void Atlas12CanvasClose()
    {
        Atlas12.SetActive(false);
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
        Atlas6.SetActive(false);
        Atlas7.SetActive(false);
        Atlas8.SetActive(false);
        Atlas9.SetActive(false);
        Atlas10.SetActive(false);
        Atlas11.SetActive(false);
        Atlas12.SetActive(false);
        dialogue.SetActive(true);
    }

}
