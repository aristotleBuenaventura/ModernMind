using UnityEngine;

public class BoxUiManager : MonoBehaviour
{
    public GameObject Box1, Box2, Box3, Box4, Box5;


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

