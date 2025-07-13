using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public GameObject OpenDoor, CloseDoor, Circle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OpenDoor.SetActive(true);
            CloseDoor.SetActive(false);
            Circle.SetActive(false);
        }
    }
}
