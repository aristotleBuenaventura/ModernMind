using UnityEngine;

public class BoxUiManager : MonoBehaviour
{
    public GameObject Box1, Box2, Box3, Box4, Box5;

    void Start()
    {
        Box1.SetActive(false);
        Box2.SetActive(false);
        Box3.SetActive(false);
        Box4.SetActive(false);
        Box5.SetActive(false);
    }

    //public void Box1Show()
    //{
    //    ShowDialogue(Box1);
    //}

    //public void Box2Show()
    //{
    //    ShowDialogue(Box2);
    //}

    //public void Box3Show()
    //{
    //    ShowDialogue(Box3);
    //}

    //public void Box4Show()
    //{
    //    ShowDialogue(Box4);
    //}

    //public void Box5Show()
    //{
    //    ShowDialogue(Box5);
    //}

    public void ShowDialogue(GameObject dialogue)
    {
        Box1.SetActive(false);
        Box2.SetActive(false);
        Box3.SetActive(false);
        Box4.SetActive(false);
        Box5.SetActive(false);
        dialogue.SetActive(true);
    }

}

