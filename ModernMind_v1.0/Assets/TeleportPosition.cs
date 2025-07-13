using UnityEngine;

public class TeleportPosition : MonoBehaviour
{
    public GameObject Player, Cube;

    public void TeleportToCube()
    {
        if (Player != null && Cube != null)
        {
            Player.transform.position = Cube.transform.position;
            Player.transform.rotation = Cube.transform.rotation;
        }
        else
        {
            Debug.LogWarning("Player or Cube is not assigned.");
        }
    }

}
