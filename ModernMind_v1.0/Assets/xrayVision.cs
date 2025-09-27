using UnityEngine;

public class xrayVision : MonoBehaviour
{
    public GameObject xrayCamera;

    // Tawagin ito kapag gusto mong i-activate ang XRay
    public void ActivateXRay()
    {
        if (xrayCamera != null)
        {
            xrayCamera.SetActive(true);
            Invoke(nameof(DeactivateXRay), 60f); // 60 seconds = 1 minute
        }
    }

    void DeactivateXRay()
    {
        if (xrayCamera != null)
        {
            xrayCamera.SetActive(false);
        }
    }
}
