using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public BoxManager manager;

    private void OnCollisionEnter(Collision collision)
    {
        BoxOpener box = collision.gameObject.GetComponent<BoxOpener>();
        if (box != null)
        {
            manager.TryOpenBox(box);
        }
    }
}
