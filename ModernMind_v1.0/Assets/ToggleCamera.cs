using UnityEngine;
using UnityEngine.UI;

public class ToggleCamera : MonoBehaviour
{
    public Toggle myToggle;
    public GameObject CameraRotation;
    public GameObject camera;      // Actual camera
    public GameObject dummyCamera; // Reference camera with desired position/rotation

    void Start()
    {
        myToggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    void OnToggleValueChanged(bool isOn)
    {
        if (isOn)
        {
            CameraRotation.SetActive(true);
        }
        else
        {
            // Copy only position and rotation
            camera.transform.position = dummyCamera.transform.position;
            camera.transform.rotation = dummyCamera.transform.rotation;

            CameraRotation.SetActive(false);
        }
    }
}
