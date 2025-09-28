using UnityEngine;

public class ChestRewardManager : MonoBehaviour
{
    public GameObject closedChest1;
    public GameObject openChest1;
    public GameObject closedChest2;
    public GameObject openChest2;
    public GameObject closedChest3;
    public GameObject openChest3;

    // 1 chest
    public Transform dummypositionchestOne_1;

    // 2 chest
    public Transform dummypositionchestTwo_1;
    public Transform dummypositionchestTwo_2;

    // 3 chest
    public Transform dummypositionchestThree_1;
    public Transform dummypositionchestThree_2;
    public Transform dummypositionchestThree_3;

    public void SetChest1()
    {
        ResetAll();

        closedChest1.SetActive(true);
        openChest1.SetActive(false);

        closedChest1.transform.position = dummypositionchestOne_1.position;
        openChest1.transform.position = dummypositionchestOne_1.position;
    }

    public void SetChest2()
    {
        ResetAll();

        closedChest1.SetActive(true);
        openChest1.SetActive(false);
        closedChest2.SetActive(true);
        openChest2.SetActive(false);

        closedChest1.transform.position = dummypositionchestTwo_1.position;
        openChest1.transform.position = dummypositionchestTwo_1.position;

        closedChest2.transform.position = dummypositionchestTwo_2.position;
        openChest2.transform.position = dummypositionchestTwo_2.position;
    }

    public void SetChest3()
    {
        ResetAll();

        closedChest1.SetActive(true);
        openChest1.SetActive(false);
        closedChest2.SetActive(true);
        openChest2.SetActive(false);
        closedChest3.SetActive(true);
        openChest3.SetActive(false);

        closedChest1.transform.position = dummypositionchestThree_1.position;
        openChest1.transform.position = dummypositionchestThree_1.position;

        closedChest2.transform.position = dummypositionchestThree_2.position;
        openChest2.transform.position = dummypositionchestThree_2.position;

        closedChest3.transform.position = dummypositionchestThree_3.position;
        openChest3.transform.position = dummypositionchestThree_3.position;
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

    void ResetAll()
    {
        closedChest1.SetActive(false);
        openChest1.SetActive(false);
        closedChest2.SetActive(false);
        openChest2.SetActive(false);
        closedChest3.SetActive(false);
        openChest3.SetActive(false);
    }
}
