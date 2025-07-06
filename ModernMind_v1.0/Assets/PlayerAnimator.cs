using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator animator;
    public Joystick joystick;
    public float walkThreshold = 0.1f;
    public float runThreshold = 0.8f;

    private bool isJumping = false;

    private void Update()
    {
        if (isJumping) return;

        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;
        Vector2 direction = new Vector2(horizontal, vertical);
        float magnitude = direction.magnitude;

        // Uncomment for debugging joystick values:
        // Debug.Log($"Horizontal: {horizontal}, Vertical: {vertical}, Magnitude: {magnitude}");

        if (magnitude < walkThreshold)
        {
            animator.Play("idle");
        }
        else
        {
            // Check downward movement first
            if (vertical < -walkThreshold && Mathf.Abs(vertical) >= Mathf.Abs(horizontal))
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
        if (!isJumping)
        {
            isJumping = true;
            animator.Play("jump");
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

        // Wait while still in "jump"
        while (animator.GetCurrentAnimatorStateInfo(0).IsName("jump") &&
               animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            yield return null;
        }

        isJumping = false;
    }
}
