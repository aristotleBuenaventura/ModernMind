using UnityEngine;

public class CarSquareDrive : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 120f;
    public float[] driveTimes = { 16f, 10f, 10f, 10f }; // time to drive each side
    public string playerTag = "Player"; // make sure your player GameObject has this tag

    private float timer = 0f;
    private int step = 0;
    private bool isTurning = false;
    private bool isStopped = false;
    private readonly float[] angles = { 180f, 90f, 0f, -90f }; // CCW angles
    private float targetY;

    void Start()
    {
        step = 0;
        targetY = angles[step];
        transform.rotation = Quaternion.Euler(0, targetY, 0);
    }

    void Update()
    {
        if (isStopped)
            return;

        timer += Time.deltaTime;

        if (!isTurning)
        {
            if (timer >= driveTimes[step])
            {
                timer = 0f;
                isTurning = true;
                step = (step + 1) % angles.Length;
                targetY = angles[step];
            }
            else
            {
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.Self);
            }
        }
        else
        {
            float currentY = transform.eulerAngles.y;
            float newY = Mathf.MoveTowardsAngle(currentY, targetY, turnSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, newY, 0);

            if (Mathf.Abs(Mathf.DeltaAngle(newY, targetY)) < 0.01f)
            {
                transform.rotation = Quaternion.Euler(0, targetY, 0);
                isTurning = false;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(playerTag))
        {
            isStopped = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag(playerTag))
        {
            isStopped = false;
        }
    }
}
