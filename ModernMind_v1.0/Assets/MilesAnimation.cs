using UnityEngine;

public class MilesAnimation : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayAnimation(string triggerName)
    {
        if (animator == null) return;

        animator.ResetTrigger("idle");
        animator.ResetTrigger("talk");

        animator.SetTrigger(triggerName);
    }
}
