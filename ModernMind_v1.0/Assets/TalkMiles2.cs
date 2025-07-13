using UnityEngine;

public class TalkMiles2 : MonoBehaviour
{
    public MilesAnimation miles;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            miles.PlayAnimation("talk");
        }
    }
}
