using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCanvasManager : MonoBehaviour
{
    public GameObject MainMenu, BagongLaro, Ipagpatuloy, TalaangPinuno, Gabay, Settings, Trivia;


    void Start()
    {
        MainMenuShow();
        BagongLaro.SetActive(false);
        Ipagpatuloy.SetActive(false);
        TalaangPinuno.SetActive(false);
        Gabay.SetActive(false);
        Settings.SetActive(false);
        Trivia.SetActive(false);
    }

    public void MainMenuShow()
    {
        ShowCanvas(MainMenu);
    }

    public void BagongLaroShow()
    {
        ShowCanvas(BagongLaro);
    }

    public void IpagpatuloyShow()
    {
        ShowCanvas(Ipagpatuloy);
    }

    public void TalaangPinunoShow()
    {
        ShowCanvas(TalaangPinuno);
    }

    public void GabayShow()
    {
        ShowCanvas(Gabay);
    }

    public void SettingsShow()
    {
        ShowCanvas(Settings);
    }

    public void TriviaShow()
    {
        ShowCanvas(Trivia);
    }

    private void ShowCanvas(GameObject canvas)
    {
        MainMenu.SetActive(false);
        BagongLaro.SetActive(false);
        Ipagpatuloy.SetActive(false);
        TalaangPinuno.SetActive(false);
        Gabay.SetActive(false);
        Settings.SetActive(false);
        Trivia.SetActive(false);
        canvas.SetActive(true);
    }

    //public void LoadScene1()
    //{
    //    SceneManager.LoadScene("Scene1");
    //    // Alternatively: SceneManager.LoadScene(1); // if using build index
    //}
}
