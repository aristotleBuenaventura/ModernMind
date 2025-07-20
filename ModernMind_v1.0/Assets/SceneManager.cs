using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Scene1()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void Scene1_Hopscotch()
    {
        SceneManager.LoadScene("Scene1_Hopscotch");
    }

    public void Scene1_Last()
    {
        SceneManager.LoadScene("Scene1_Last");
    }
}
