using UnityEngine;

public class PlatformCounter : MonoBehaviour
{
    public GameObject[] cubes;      // Assign your platform cubes in the Inspector
    public GameObject PlayerCube;   // Assign your player GameObject here
    public int counter = 0;

    public void counterIncrement()
    {
        // Only increment if within bounds
        if (counter < cubes.Length)
        {
            PlayerCube.transform.position = cubes[counter].transform.position;
            counter++;
        }
        else
        {
            Debug.Log("All platforms visited!");
        }
    }
}
