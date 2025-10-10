using UnityEngine;
using TMPro;
using System.Collections;

public class WoodTransfer : MonoBehaviour
{
    [Header("References")]
    public WoodCounter woodCounter;        // ✅ Reference to your WoodCounter script
    public TextMeshProUGUI bridgeText;     // ✅ TMP Text for message display

    [Header("Transfer Settings")]
    public int woodToTransfer = 5;         // ✅ Number of woods to move
    public float transferDelay = 1f;       // ✅ 1 second per wood

    private bool isPlayerInside = false;   // ✅ Tracks if player is inside the trigger
    private bool isTransferring = false;
    private int remaining;
    public GameObject brokenBridge, fixBridge;

    private Coroutine transferCoroutine;

    private void Start()
    {
        remaining = woodToTransfer;
        UpdateBridgeText(remaining);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
            Debug.Log("🪵 Player entered bridge zone. Starting wood transfer...");
            if (!isTransferring)
                transferCoroutine = StartCoroutine(TransferWoodRoutine());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
            Debug.Log("🚶 Player left bridge zone. Pausing transfer...");
        }
    }

    private IEnumerator TransferWoodRoutine()
    {
        isTransferring = true;

        while (remaining > 0)
        {
            // Wait until player is inside before continuing
            yield return new WaitUntil(() => isPlayerInside);

            // ✅ 1-second delay per transfer
            yield return new WaitForSeconds(transferDelay);

            // ✅ Only decrement if there’s wood left
            if (woodCounter != null && woodCounter.woodCount > 0)
            {
                woodCounter.Decrement();
                remaining--;
                UpdateBridgeText(remaining);
                Debug.Log($"🌲 Transferred 1 wood. Remaining: {remaining}");
            }
            else
            {
                Debug.LogWarning("⚠️ Not enough wood to continue transfer!");
                break;
            }
        }

        // ✅ Done transferring
        if (remaining <= 0)
        {
            Debug.Log("✅ Bridge fixed!");
            brokenBridge.SetActive(false);
            fixBridge.SetActive(true);
            bridgeText.text = "Bridge fixed! 🎉";
        }

        isTransferring = false;
    }

    private void UpdateBridgeText(int remaining)
    {
        if (bridgeText != null)
        {
            bridgeText.text = $"You need {remaining} more woods to fix the bridge!";
        }
    }
}
