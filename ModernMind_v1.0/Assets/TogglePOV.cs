using UnityEngine;
using UnityEngine.UI;

public class TogglePOV : MonoBehaviour
{
    public Toggle myToggle;
    public GameObject thirdCamera, firstCamera;

    void Start()
    {
        // Subscribe to toggle change
        myToggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    void OnToggleValueChanged(bool isOn)
    {
        if (isOn)
        {
            thirdCamera.SetActive(false);
            firstCamera.SetActive(true);
        }
        else
        {
            thirdCamera.SetActive(true);
            firstCamera.SetActive(false);
        }
    }
}
