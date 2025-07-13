using UnityEngine;

public class FisherYatesAlgorithm : MonoBehaviour
{
    // Assign your 10 GameObjects in the Inspector
    public GameObject[] objectsToShuffle;

    void Start()
    {
        ShuffleObjects();
    }

    public void ShuffleObjects()
    {
        for (int i = objectsToShuffle.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1); // 0 ≤ j ≤ i

            // Swap their positions in the scene
            Vector3 tempPosition = objectsToShuffle[i].transform.position;
            objectsToShuffle[i].transform.position = objectsToShuffle[j].transform.position;
            objectsToShuffle[j].transform.position = tempPosition;

            // Swap their references in the array
            GameObject temp = objectsToShuffle[i];
            objectsToShuffle[i] = objectsToShuffle[j];
            objectsToShuffle[j] = temp;
        }
    }
}
