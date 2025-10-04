using UnityEngine;
using System.Collections;

public class RemoveMap : MonoBehaviour
{
    public GameObject mapUI, mapCanvas;

    private void Update()
    {
        if (mapUI != null && mapUI.activeSelf && !isRunning)
        {
            StartCoroutine(HideMapAfterDelay());
        }
    }

    private bool isRunning = false;

    private IEnumerator HideMapAfterDelay()
    {
        isRunning = true;
        yield return new WaitForSeconds(30f);
        if (mapUI != null) mapUI.SetActive(false);
        if (mapCanvas != null) mapCanvas.SetActive(false);
        isRunning = false;
    }
}
