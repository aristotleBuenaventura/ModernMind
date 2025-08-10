using System.Collections;
using TMPro;
using UnityEngine;

public class TypewriterEffect2 : MonoBehaviour
{
    public TextMeshProUGUI[] textMeshPros; // Array to hold 6 TextMeshPro components
    public float typingSpeed = 0.06f; // Speed of typing (lower is faster)
    public float delayBetweenTexts = 0.5f; // Delay before the next text starts

    private string[] fullTexts;
    private Coroutine typingCoroutine;

    void Start()
    {

        // Store full texts and clear initial texts
        fullTexts = new string[textMeshPros.Length];
        for (int i = 0; i < textMeshPros.Length; i++)
        {
            fullTexts[i] = textMeshPros[i].text;
            textMeshPros[i].text = ""; // Clear text initially
        }

        StartTypewriter(); // Start the typewriter effect
    }

    public void StartTypewriter()
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeTextSequence());
    }

    private IEnumerator TypeTextSequence()
    {
        for (int i = 0; i < textMeshPros.Length; i++)
        {
            yield return StartCoroutine(TypeText(textMeshPros[i], fullTexts[i]));
            yield return new WaitForSeconds(delayBetweenTexts); // Delay before the next text starts
        }
    }

    private IEnumerator TypeText(TextMeshProUGUI textMesh, string fullText)
    {
        textMesh.text = ""; // Clear text before typing

        foreach (char letter in fullText.ToCharArray())
        {
            textMesh.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}