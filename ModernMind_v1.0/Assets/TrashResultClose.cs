using UnityEngine;

public class TrashResultClose : MonoBehaviour
{
    public GameObject Tumpak, Mali;
    public ShowUI bag;

    public void ResultClose()
    {
        Tumpak.SetActive(false);
        Mali.SetActive(false);
        bag.UICanvasShow();
        Debug.Log("Bug");
    }

    public void TumpakShow()
    {
        Tumpak.SetActive(true);
        Mali.SetActive(false);
        bag.UICanvasClose();
    }

    public void MaliShow()
    {
        Tumpak.SetActive(false);
        Mali.SetActive(true);
        bag.UICanvasClose();
    }
}
