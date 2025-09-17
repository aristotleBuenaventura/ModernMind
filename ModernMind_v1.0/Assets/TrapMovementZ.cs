using UnityEngine;

public class TrapMovementZ : MonoBehaviour
{
    public GameObject trap;
    public float distance = 5f;
    public float speed = 2f;
    public string startDirection = "right"; // "right" or "left"

    private float startZ;
    private int dirMultiplier = 1;

    void Start()
    {
        if (trap == null) trap = gameObject;
        startZ = trap.transform.position.z;

        if (startDirection.ToLower() == "left")
            dirMultiplier = -1;
        else
            dirMultiplier = 1;
    }

    void Update()
    {
        float newZ = startZ + dirMultiplier * Mathf.PingPong(Time.time * speed, distance);
        trap.transform.position = new Vector3(trap.transform.position.x, trap.transform.position.y, newZ);
    }
}
