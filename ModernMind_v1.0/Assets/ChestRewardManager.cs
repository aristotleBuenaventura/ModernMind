using UnityEngine;
using UnityEngine.UI;

public class ChestRewardManager : MonoBehaviour
{
    public GameObject closedChest1;
    public GameObject openChest1;
    public GameObject closedChest2;
    public GameObject openChest2;
    public GameObject closedChest3;
    public GameObject openChest3;

    public void SetChest1()
    {
        closedChest1.SetActive(true);
        openChest1.SetActive(false);
    }

    public void SetChest2()
    {
        closedChest1.SetActive(true);
        openChest1.SetActive(false);
        closedChest2.SetActive(true);
        openChest2.SetActive(false);
    }

    public void SetChest3()
    {
        closedChest1.SetActive(true);
        openChest1.SetActive(false);
        closedChest2.SetActive(true);
        openChest2.SetActive(false);
        closedChest3.SetActive(true);
        openChest3.SetActive(false);
    }

    public void OpenChest1()
    {
        closedChest1.SetActive(false);
        openChest1.SetActive(true);
    }

    public void OpenChest2()
    {
        closedChest2.SetActive(false);
        openChest2.SetActive(true);
    }

    public void OpenChest3()
    {
        closedChest3.SetActive(false);
        openChest3.SetActive(true);
    }

}
