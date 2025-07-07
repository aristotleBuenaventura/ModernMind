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
    private bool isWalkingBack = false;
    private bool isPicking = false;

    private Rigidbody rb;

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
        if (!isPicking)
        {
            HandleMovement();
        }

        if (!isJumping && !isPicking)
        {
            HandleAnimation();
        }
    }

    private void HandleMovement()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;
        float magnitude = new Vector2(horizontal, vertical).magnitude;

        isWalkingBack = false;

        if (Mathf.Abs(horizontal) > 0.1f)
        {
            float rotationAmount = horizontal * rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, rotationAmount);
        }

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
        if (!isJumping && isGrounded && !isPicking)
        {
            isJumping = true;
            isGrounded = false;
            animator.Play("jump");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            StartCoroutine(ResetJumpAfterAnimation());
        }
    }

    public void Pick()
    {
        if (!isPicking && !isJumping)
        {
            isPicking = true;
            animator.Play("pick");
            StartCoroutine(ResetPickAfterAnimation());
        }
    }

    private System.Collections.IEnumerator ResetPickAfterAnimation()
    {
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName("pick"))
        {
            yield return null;
        }

        while (animator.GetCurrentAnimatorStateInfo(0).IsName("pick") &&
               animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
        {
            yield return null;
        }

        isPicking = false;
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

    private void OnAnimatorIK(int layerIndex)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("pick"))
        {
            // Apply IK to keep feet in place
            animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1);
            animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1);
            animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 1);

            Vector3 footPos = transform.position + Vector3.up * 0.05f;

            animator.SetIKPosition(AvatarIKGoal.LeftFoot, footPos);
            animator.SetIKRotation(AvatarIKGoal.LeftFoot, transform.rotation);
            animator.SetIKPosition(AvatarIKGoal.RightFoot, footPos);
            animator.SetIKRotation(AvatarIKGoal.RightFoot, transform.rotation);
        }
        else
        {
            // Clear IK when not picking
            animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 0);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 0);
            animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 0);
            animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 0);
        }
    }
}
