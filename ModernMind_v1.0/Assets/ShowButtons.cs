using UnityEngine;

public class ShowButtons : MonoBehaviour
{
    public GameObject button1, button2, button3;

    public void Antas1()
    {
        button1.SetActive(true);
        button2.SetActive(false);
        button3.SetActive(false);
    }

    public void Antas2()
    {
        button1.SetActive(false);
        button2.SetActive(true);
        button3.SetActive(false);
    }

    public void Antas3()
    {
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(true);
    }
}
