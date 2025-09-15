using UnityEngine;

public class ApproachAtlas : MonoBehaviour
{
    public GameObject task, mahusay, layunin, check, circle, taskIcon;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            taskIcon.SetActive(false);
            task.SetActive(true);
            layunin.SetActive(false);
            mahusay.SetActive(true);
            check.SetActive(true);
            circle.SetActive(false);
        }
    }
}
