using UnityEngine;

public class TalkMiles3 : MonoBehaviour
{
    public MilesAnimation miles;
    public Scene1_HopscotchCanvasManager canvas;
    public PlayerAnimator player;
    public GameObject circle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            miles.PlayAnimation("talk");
            canvas.FourthMilesShow();
            player.ForceIdle();
            circle.SetActive(false);
        }
    }
}
