using UnityEngine;

public class PlatformCounter : MonoBehaviour
{
    public GameObject[] cubes;      // Assign your platform cubes in the Inspector
    public GameObject PlayerCube;   // Assign your player GameObject here
    public int counter = 0;
    public GameObject player;

    // Moves player to the next cube (normal step)
    public void counterIncrement()
    {
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

    // Just increase counter without moving player
    public void counterPlus()
    {
        counter++;
    }

    // NEW: Skip function - teleport directly to the next cube
    public void SkipToNextCube()
    {
        if (counter < cubes.Length)
        {
            // Teleport player to the next cube instantly
            player.transform.position = cubes[counter].transform.position;
            PlayerCube.transform.position = cubes[counter].transform.position;
            Debug.Log("Skipped to cube: " + counter);

            counter++; // Move counter forward
        }
        else
        {
            Debug.Log("No more cubes to skip!");
        }
    }
}
