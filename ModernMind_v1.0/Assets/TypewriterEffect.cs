using System.Collections;
using TMPro;
using UnityEngine;

public class TypewriterEffect : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; // Reference to the TextMeshPro component
    public float typingSpeed = 0.06f; // Speed of typing (lower is faster)

    private string fullText;
    private Coroutine typingCoroutine;

    void Start()
    {
        if (textMeshPro == null)
            textMeshPro = GetComponent<TextMeshProUGUI>();

        fullText = textMeshPro.text; // Store the full text
        textMeshPro.text = ""; // Clear initial text

        StartTypewriter(); // Start the typewriter effect
    }

    public void StartTypewriter()
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        textMeshPro.text = ""; // Clear text before typing

        foreach (char letter in fullText.ToCharArray())
        {
            textMeshPro.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}