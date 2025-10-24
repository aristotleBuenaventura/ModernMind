using UnityEngine;

public class Scene3Redlight : MonoBehaviour
{
    public GameObject loading, First, Second, Third, loading2, Fourth, Fifth, Sixth, Seventh, Eighth, Ninth, Eleventh, Twelveth;
    public GameObject Thirteenth, Fourteenth, Fifteenth;
    public GameObject loading3, Sixteenth, Seventeenth, Eighteenth, Ninteenth;
    public GameObject c20, c21, c22, c23, c24, c25, c26, c27, c28, c29;


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
        loading3.SetActive(false);
        Sixteenth.SetActive(false);
        Seventeenth.SetActive(false);
        Eighteenth.SetActive(false);
        Ninteenth.SetActive(false);
        c20.SetActive(false);
        c21.SetActive(false);
        c22.SetActive(false);
        c23.SetActive(false);
        c24.SetActive(false);
        c25.SetActive(false);
        c26.SetActive(false);
        c27.SetActive(false);
        c28.SetActive(false);
        c29.SetActive(false);
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

    public void loading3CanvasShow()
    {
        ShowDialogue(loading3);
    }

    public void SixteenthCanvasShow()
    {
        ShowDialogue(Sixteenth);
    }

    public void SeventeenthCanvasShow()
    {
        ShowDialogue(Seventeenth);
    }

    public void EighteenthCanvasShow()
    {
        ShowDialogue(Eighteenth);
    }

    public void NinteenthCanvasShow()
    {
        ShowDialogue(Ninteenth);
    }

    public void NinteenthCanvasClose()
    {
        Ninteenth.SetActive(false);
    }

    public void c20CanvasShow()
    {
        ShowDialogue(c20);
    }

    public void c21CanvasShow()
    {
        ShowDialogue(c21);
    }

    public void c22CanvasShow()
    {
        ShowDialogue(c22);
    }

    public void c23CanvasShow()
    {
        ShowDialogue(c23);
    }

    public void c24CanvasShow()
    {
        ShowDialogue(c24);
    }

    public void c25CanvasShow()
    {
        ShowDialogue(c25);
    }

    public void c26CanvasShow()
    {
        ShowDialogue(c26);
    }

    public void c27CanvasShow()
    {
        ShowDialogue(c27);
    }

    public void c28CanvasShow()
    {
        ShowDialogue(c28);
    }

    public void c29CanvasShow()
    {
        ShowDialogue(c29);
    }

    public void c29CanvasClose()
    {
        c29.SetActive(false);
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
        loading3.SetActive(false);
        Sixteenth.SetActive(false);
        Seventeenth.SetActive(false);
        Eighteenth.SetActive(false);
        Ninteenth.SetActive(false);
        c20.SetActive(false);
        c21.SetActive(false);
        c22.SetActive(false);
        c23.SetActive(false);
        c24.SetActive(false);
        c25.SetActive(false);
        c26.SetActive(false);
        c27.SetActive(false);
        c28.SetActive(false);
        c29.SetActive(false);

        dialogue.SetActive(true);
    }

}
