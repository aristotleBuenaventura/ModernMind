using UnityEngine;

public class TalkMiles2 : MonoBehaviour
{
    public MilesAnimation miles;
    public Scene1CanvasManager canvas;
    public PlayerAnimator player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            miles.PlayAnimation("talk");
            canvas.TenthCanvasShow();
            player.ForceIdle();
        }
    }
}
