using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator animator;
    public Joystick joystick;
    public float walkThreshold = 0.1f;
    public float runThreshold = 0.8f;
    public float walkSpeed = 2f;
    public float runSpeed = 5f;
    public float jumpForce = 5f;

    private bool isJumping = false;
    private bool isGrounded = true;
    private Rigidbody rb;
    private bool isWalkingBack = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody not found on the player.");
        }
    }

    private void Update()
    {
        if (!isJumping)
        {
            HandleMovementAndAnimation();
        }
    }

    private void HandleMovementAndAnimation()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;
        Vector2 direction = new Vector2(horizontal, vertical);
        float magnitude = direction.magnitude;
        isWalkingBack = false;

        // Animation
        if (magnitude < walkThreshold)
        {
            animator.Play("idle");
        }
        else
        {
            if (vertical < -walkThreshold && Mathf.Abs(vertical) >= Mathf.Abs(horizontal))
            {
                animator.Play("walkback");
                isWalkingBack = true;
            }
            else if (magnitude >= runThreshold)
            {
                animator.Play("run");
            }
            else
            {
                animator.Play("walk");
            }
        }

        // Movement
        Vector3 inputDir = new Vector3(horizontal, 0, vertical).normalized;
        float speed = (magnitude >= runThreshold) ? runSpeed : walkSpeed;

        if (inputDir.magnitude >= 0.01f)
        {
            Quaternion toRotation = Quaternion.LookRotation(inputDir, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.deltaTime * 10f);

            Vector3 moveDir = isWalkingBack ? -transform.forward : transform.forward;
            Vector3 newPos = rb.position + moveDir * speed * Time.deltaTime;
            rb.MovePosition(newPos);
        }
    }

    public void Jump()
    {
        if (!isJumping && isGrounded)
        {
            isJumping = true;
            isGrounded = false;
            animator.Play("jump");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            StartCoroutine(ResetJumpAfterAnimation());
        }
    }

    private System.Collections.IEnumerator ResetJumpAfterAnimation()
    {
        // Wait until jump animation starts
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName("jump"))
        {
            yield return null;
        }

        // Wait while still in jump animation
        while (animator.GetCurrentAnimatorStateInfo(0).IsName("jump") &&
               animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            yield return null;
        }

        isJumping = false;
    }

    // This detects when player lands on the ground
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
