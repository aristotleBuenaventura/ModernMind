using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class KeyManager : MonoBehaviour
{
    public static KeyManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI keyText; // Reference to the TextMeshPro UI element

    private int keyCount = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateKeyText();
    }

    public void IncrementKey(int amount)
    {
        keyCount += amount;
        UpdateKeyText();
    }

    private void UpdateKeyText()
    {
        if (keyText != null)
        {
            keyText.text = "x " + keyCount;
        }
   }

    // Getter function to retrieve the current key count
    public int GetKeyCount()
    {
        return keyCount;
    }
}
