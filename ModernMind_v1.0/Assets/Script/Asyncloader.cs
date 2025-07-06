using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Asyncloader : MonoBehaviour
{
    [SerializeField] private GameObject loadingscreen;
    [SerializeField] private GameObject mainMenu;

    [Header("slider")]
    [SerializeField] private Slider loadingslider;

    public void LoadLevelBtn(string levelToload)
    {
        mainMenu.SetActive(false);
        loadingscreen.SetActive(true);

        StartCoroutine(LoadLevelASync(levelToload));
    }

    IEnumerator LoadLevelASync(string levelToload)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToload);
        while (!loadOperation.isDone)
        {
            float progressValue = Mathf.Clamp01(loadOperation.progress / 0.5f);
            loadingslider.value = progressValue;
            yield return null;
        }
    }
}
