using UnityEngine;

public class TrapMovementX : MonoBehaviour
{
    public GameObject trap;
    public float distance = 5f;
    public float speed = 2f;
    public string startDirection = "right"; // "right" or "left"

    private float startX;
    private int dirMultiplier = 1;

    void Start()
    {
        if (trap == null) trap = gameObject;
        startX = trap.transform.position.x;

        if (startDirection.ToLower() == "left")
            dirMultiplier = -1;
        else
            dirMultiplier = 1;
    }

    void Update()
    {
        float newX = startX + dirMultiplier * Mathf.PingPong(Time.time * speed, distance);
        trap.transform.position = new Vector3(newX, trap.transform.position.y, trap.transform.position.z);
    }
}
