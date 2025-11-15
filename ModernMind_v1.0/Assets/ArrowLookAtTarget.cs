using UnityEngine;

public class ArrowOrbitPlayer : MonoBehaviour
{
    public Transform player;
    public Transform target;

    public float radius = 1.5f;
    public float heightOffset = 1f;
    public float rotationSpeed = 5f;

    void Update()
    {
        if (!player || !target) return;

        Vector3 dir = (target.position - player.position).normalized;
        dir.y = 0;

        Vector3 orbitPos = player.position + dir * radius;
        orbitPos.y += heightOffset;

        transform.position = Vector3.Lerp(transform.position, orbitPos, Time.deltaTime * rotationSpeed);

        Vector3 lookDir = target.position - transform.position;
        lookDir.y = 0;

        if (lookDir.sqrMagnitude > 0.001f)
        {
            Quaternion lookRot = Quaternion.LookRotation(lookDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * rotationSpeed);
        }
    }
}
