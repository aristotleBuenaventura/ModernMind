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

    private bool isTransferring = false;
    public GameObject brokenBridge, fixBridge;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTransferring)
        {
            Debug.Log("🪵 Player entered bridge zone. Starting wood transfer...");
            StartCoroutine(TransferWoodRoutine());
        }
    }

    private IEnumerator TransferWoodRoutine()
    {
        isTransferring = true;

        int remaining = woodToTransfer;
        UpdateBridgeText(remaining);

        while (remaining > 0)
        {
            // ✅ Wait before each transfer (1 sec delay)
            yield return new WaitForSeconds(transferDelay);

            // ✅ Only decrement if there’s wood left
            if (woodCounter != null && woodCounter.woodCount > 0)
            {
                woodCounter.Decrement();
                remaining--;
                UpdateBridgeText(remaining);
            }
            else
            {
                Debug.LogWarning("⚠️ Not enough wood to continue transfer!");
                break;
            }
        }

        if (remaining <= 0)
        {
            Debug.Log("✅ Done transferring woods!");
            brokenBridge.SetActive(false);
            fixBridge.SetActive(true);
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
