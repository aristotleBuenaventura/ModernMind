using UnityEngine;

public class NPCSquareWalk : MonoBehaviour
{
    public Animator animator;
    public float turnSpeed = 120f;
    public float moveSpeed = 2f;
    public float[] walkTimes = { 16f, 16f, 16f, 16f }; // per-side walk time
    public string playerTag = "Player"; // tag for player

    private float timer = 0f;
    private int step = 0;
    private bool isTurning = false;
    private bool isStopped = false;
    private readonly float[] angles = { -90f, -180f, -270f, 0f }; // CW order
    private float targetY;

    void Start()
    {
        animator.applyRootMotion = false;
        step = 0;
        targetY = angles[step];
        transform.rotation = Quaternion.Euler(0, targetY, 0);
        animator.SetTrigger("walk");
    }

    void Update()
    {
        if (isStopped)
            return;

        timer += Time.deltaTime;

        if (!isTurning)
        {
            if (timer >= walkTimes[step])
            {
                timer = 0f;
                isTurning = true;
                step = (step + 1) % angles.Length;
                targetY = angles[step];
                animator.SetTrigger("left");
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
                animator.SetTrigger("walk");
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
