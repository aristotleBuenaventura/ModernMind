using UnityEngine;

public class FisherYatesAlgorithm : MonoBehaviour
{
    public GameObject[] objectsToShuffle;
    public int[] shuffledOrder; // Stores the final sequence of indices

    void Start()
    {
        ShuffleObjects();
    }

    public void ShuffleObjects()
    {
        int length = objectsToShuffle.Length;
        shuffledOrder = new int[length];

        // Initialize the index order [0, 1, 2, ..., length-1]
        for (int i = 0; i < length; i++)
        {
            shuffledOrder[i] = i;
        }

        // Perform Fisher-Yates Shuffle on both GameObjects and index array
        for (int i = length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);

            // Swap positions of GameObjects
            Vector3 tempPosition = objectsToShuffle[i].transform.position;
            objectsToShuffle[i].transform.position = objectsToShuffle[j].transform.position;
            objectsToShuffle[j].transform.position = tempPosition;

            // Swap GameObjects in array
            GameObject tempGO = objectsToShuffle[i];
            objectsToShuffle[i] = objectsToShuffle[j];
            objectsToShuffle[j] = tempGO;

            // Swap their indices in the shuffledOrder array
            int tempIndex = shuffledOrder[i];
            shuffledOrder[i] = shuffledOrder[j];
            shuffledOrder[j] = tempIndex;
        }

        // Debug log the final order
        string result = "Shuffled Order: [";
        for (int i = 0; i < length; i++)
        {
            result += shuffledOrder[i] + (i < length - 1 ? ", " : "]");
        }
        Debug.Log(result);
    }
}
