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

    public void Scene1_Search()
    {
        SceneManager.LoadScene("Scene1_Search");
    }

    public void Gabay()
    {
        SceneManager.LoadScene("Gabay");
    }

    public void Scene2()
    {
        SceneManager.LoadScene("Scene2");
    }

    public void Scene2_Hopscotch()
    {
        SceneManager.LoadScene("Scene2_Hopscotch");
    }

    public void Scene2_Maze()
    {
        SceneManager.LoadScene("Scene2_Maze");
    }

    public void Scene3_Hopscotch()
    {
        SceneManager.LoadScene("Scene3_Hopscotch");
    }

    public void Scene3_Bridge()
    {
        SceneManager.LoadScene("Scene3_Bridge");
    }

}
