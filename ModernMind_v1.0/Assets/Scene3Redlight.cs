using UnityEngine;

public class Scene3Redlight : MonoBehaviour
{
    public GameObject loading, First, Second, Third, loading2, Fourth, Fifth, Sixth, Seventh, Eighth, Ninth, Eleventh, Twelveth;
    public GameObject Thirteenth, Fourteenth, Fifteenth;

    void Start()
    {
        loading.SetActive(true);
        First.SetActive(false);
        Second.SetActive(false);
        Third.SetActive(false);
        loading2.SetActive(false);
        Fourth.SetActive(false);
        Fifth.SetActive(false);
        Sixth.SetActive(false);
        Seventh.SetActive(false);
        Eighth.SetActive(false);
        Ninth.SetActive(false);
        Eleventh.SetActive(false);
        Twelveth.SetActive(false);
        Thirteenth.SetActive(false);
        Fourteenth.SetActive(false);
        Fifteenth.SetActive(false);
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

    public void SeventhCanvasShow()
    {
        ShowDialogue(Seventh);
    }

    public void EighthCanvasShow()
    {
        ShowDialogue(Eighth);
    }

    public void NinthCanvasShow()
    {
        ShowDialogue(Ninth);
    }

    public void EleventhCanvasShow()
    {
        ShowDialogue(Eleventh);
    }

    public void TwelvethCanvasShow()
    {
        ShowDialogue(Twelveth);
    }

    public void TwelvethCanvasClose()
    {
        Twelveth.SetActive(false);
    }

    public void LoadingShow()
    {
        ShowDialogue(loading);
    }

    public void Loading2Show()
    {
        ShowDialogue(loading2);
    }

    public void ThirteenthCanvasShow()
    {
        ShowDialogue(Thirteenth);
    }

    public void FourteenthCanvasShow()
    {
        ShowDialogue(Fourteenth);
    }

    public void FifteenthCanvasShow()
    {
        ShowDialogue(Fifteenth);
    }

    public void FifteenthCanvasClose()
    {
        Fifteenth.SetActive(false);
    }


    private void ShowDialogue(GameObject dialogue)
    {
        loading.SetActive(false);
        First.SetActive(false);
        Second.SetActive(false);
        Third.SetActive(false);
        loading2.SetActive(false);
        Fourth.SetActive(false);
        Fifth.SetActive(false);
        Sixth.SetActive(false);
        Seventh.SetActive(false);
        Eighth.SetActive(false);
        Ninth.SetActive(false);
        Eleventh.SetActive(false);
        Twelveth.SetActive(false);
        Thirteenth.SetActive(false);
        Fourteenth.SetActive(false);
        Fifteenth.SetActive(false);

        dialogue.SetActive(true);
    }

}
