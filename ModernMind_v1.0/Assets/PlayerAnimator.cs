using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator animator;
    public Joystick joystick;
    public float walkThreshold = 0.1f;
    public float runThreshold = 0.8f;
    public float walkSpeed = 2f;
    public float runSpeed = 5f;
    public float rotationSpeed = 100f;
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
        HandleMovement(); // Always move/rotate
        if (!isJumping)
        {
            HandleAnimation(); // Only play walk/run/back animations if not jumping
        }
    }

    private void HandleMovement()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;
        float magnitude = new Vector2(horizontal, vertical).magnitude;

        isWalkingBack = false;

        // Rotate left/right
        if (Mathf.Abs(horizontal) > 0.1f)
        {
            float rotationAmount = horizontal * rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, rotationAmount);
        }

        // Move forward/backward
        if (Mathf.Abs(vertical) > walkThreshold)
        {
            float speed = (magnitude >= runThreshold) ? runSpeed : walkSpeed;
            Vector3 moveDir = transform.forward * vertical * speed * Time.deltaTime;
            rb.MovePosition(rb.position + moveDir);

            if (vertical < -walkThreshold)
            {
                isWalkingBack = true;
            }
        }
    }

    private void HandleAnimation()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;
        float magnitude = new Vector2(horizontal, vertical).magnitude;

        if (magnitude < walkThreshold)
        {
            animator.Play("idle");
        }
        else
        {
            if (vertical < -walkThreshold)
            {
                animator.Play("walkback");
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
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName("jump"))
        {
            yield return null;
        }

        while (animator.GetCurrentAnimatorStateInfo(0).IsName("jump") &&
               animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            yield return null;
        }

        isJumping = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
