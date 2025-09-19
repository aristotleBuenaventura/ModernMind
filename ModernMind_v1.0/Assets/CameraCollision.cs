using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public Transform player;       // reference to player
    public float smooth = 10f;     // smoothing speed
    public float minDistance = 1f; // minimum zoom (pag dikit sa wall)
    public float maxDistance = 4f; // normal distance
    public float offsetY = 1.5f;   // taas ng camera galing sa player
    public string[] ignoreTags;    // list ng tags na hindi rereact ang camera

    private float currentDistance;

    void Start()
    {
        currentDistance = maxDistance;
    }

    void LateUpdate()
    {
        Vector3 origin = player.position + Vector3.up * offsetY;

        RaycastHit hit;
        if (Physics.Raycast(origin, -transform.forward, out hit, maxDistance))
        {
            // check kung ang collider ay may tag na dapat i-ignore
            bool shouldIgnore = false;
            foreach (string t in ignoreTags)
            {
                if (hit.collider.CompareTag(t))
                {
                    shouldIgnore = true;
                    break;
                }
            }

            if (!shouldIgnore)
            {
                currentDistance = Mathf.Clamp(hit.distance, minDistance, maxDistance);
            }
        }
        else
        {
            currentDistance = Mathf.Lerp(currentDistance, maxDistance, Time.deltaTime * smooth);
        }

        transform.position = player.position - transform.forward * currentDistance + Vector3.up * offsetY;
    }
}
