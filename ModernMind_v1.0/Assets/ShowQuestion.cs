using UnityEngine;
using TMPro;   // ✅ Correct namespace

public class ShowQuestion : MonoBehaviour
{
    public GameObject PlayerCube, cube;
    public GameObject question;
    private bool hasTriggered = false;

    [TextArea] public string hint;
    public TextMeshProUGUI textHint;  // ✅ Correct TMPRO type

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true;

            // Move player to cube position
            PlayerCube.transform.position = cube.transform.position;

            // Show the question
            question.SetActive(true);

            // Display hint
            textHint.text = hint;
        }
    }
}
