using UnityEngine;

public class TalkMiles4: MonoBehaviour
{
    public GameObject canvas, check, circle, circle2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.SetActive(true);
            check.SetActive(true);
            circle.SetActive(true);
            circle2.SetActive(false);
        }
    }
}
