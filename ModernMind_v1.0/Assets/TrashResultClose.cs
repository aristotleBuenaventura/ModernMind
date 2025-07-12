using UnityEngine;

public class TrashResultClose : MonoBehaviour
{
    public GameObject Result1, Result2;
    public ShowUI bag;

    public void ResultClose()
    {
        Result1.SetActive(false);
        Result2.SetActive(false);
        bag.UICanvasShow();
    }
}
