using UnityEngine;

public class Scene3Bridge : MonoBehaviour
{
    public GameObject Loading, Lesbian1, Lesbian2, Gay1, Gay2, Bisexual1, Bisexual2, Transgender1, Transgender2, Queer1, Queer2;
    public GameObject Lesbian, LesbianWords, LesbianCircle;
    public GameObject Gay, GayWords, GayCircle;
    public GameObject Bisexual, BisexualWords, BisexualCircle;
    public GameObject Transgender, TransgenderWords, TransgenderCircle;
    public GameObject Queer, QueerWords, QueerCircle;
    public TimerDisplay timer;

    void Start()
    {
        LoadingCanvasShow();
        Lesbian1.SetActive(false);
        Lesbian2.SetActive(false);
        Gay1.SetActive(false);
        Gay2.SetActive(false);
        Bisexual1.SetActive(false);
        Bisexual2.SetActive(false);
        Transgender1.SetActive(false);
        Transgender2.SetActive(false);
        Queer1.SetActive(false);
        Queer2.SetActive(false);
        Lesbian.SetActive(false);
        LesbianWords.SetActive(false);
        LesbianCircle.SetActive(false);
        Gay.SetActive(false);
        GayWords.SetActive(false);
        GayCircle.SetActive(false);
        Bisexual.SetActive(false);
        BisexualWords.SetActive(false);
        BisexualCircle.SetActive(false);
        Transgender.SetActive(false);
        TransgenderWords.SetActive(false);
        TransgenderCircle.SetActive(false);
        Queer.SetActive(false);
        QueerWords.SetActive(false);
        QueerCircle.SetActive(false);

    }

    public void LoadingCanvasShow()
    {
        ShowDialogue(Loading);
    }

    public void LoadingCanvasClose()
    {
        Loading.SetActive(false);
        Lesbian.SetActive(true);
        timer.StartTimer();
    }

    public void Lesbian1CanvasShow()
    {
        ShowDialogue(Lesbian1);
    }

    public void Lesbian2CanvasShow()
    {
        ShowDialogue(Lesbian2);
        
    }

    public void Lesbian2CanvasClose()
    {
        Lesbian2.SetActive(false);
        LesbianWords.SetActive(true);
        LesbianCircle.SetActive(true);
    }

    public void Gay1CanvasShow()
    {
        ShowDialogue(Gay1);
    }

    public void Gay2CanvasShow()
    {
        ShowDialogue(Gay2);
    }

    public void Gay2CanvasClose()
    {
        Gay2.SetActive(false);
        GayWords.SetActive(true);
        GayCircle.SetActive(true);
    }

    public void Bisexual1CanvasShow()
    {
        ShowDialogue(Bisexual1);
    }

    public void Bisexual2CanvasShow()
    {
        ShowDialogue(Bisexual2);
    }

    public void Bisexual2CanvasClose()
    {
        Bisexual2.SetActive(false);
        BisexualWords.SetActive(true);
        BisexualCircle.SetActive(true);
    }

    public void Transgender1CanvasShow()
    {
        ShowDialogue(Transgender1);
    }

    public void Transgender2CanvasShow()
    {
        ShowDialogue(Transgender2);
    }

    public void Transgender2CanvasClose()
    {
        Transgender2.SetActive(false);
        TransgenderWords.SetActive(true);
        TransgenderCircle.SetActive(true);
    }

    public void Queer1CanvasShow()
    {
        ShowDialogue(Queer1);
    }

    public void Queer2CanvasShow()
    {
        ShowDialogue(Queer2);
    }

    public void Queer2CanvasClose()
    {
        Queer2.SetActive(false);
        QueerWords.SetActive(true);
        QueerCircle.SetActive(true);
    }

    private void ShowDialogue(GameObject dialogue)
    {
        Loading.SetActive(false);
        Lesbian1.SetActive(false);
        Lesbian2.SetActive(false);
        Gay1.SetActive(false);
        Gay2.SetActive(false);
        Bisexual1.SetActive(false);
        Bisexual2.SetActive(false);
        Transgender1.SetActive(false);
        Transgender2.SetActive(false);
        Queer1.SetActive(false);
        Queer2.SetActive(false);
        dialogue.SetActive(true);
    }


}
