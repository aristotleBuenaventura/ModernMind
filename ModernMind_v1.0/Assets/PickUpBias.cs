using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickUpBias : MonoBehaviour
{
    [Header("Collected Bias Placeholders (3D)")]
    public List<GameObject> biasPlaceholders;

    [Header("Bias UI Images")]
    public List<GameObject> biasImages;

    [Header("Other UI Objects")]
    public GameObject completeCanvas, checkTask;

    private Dictionary<string, GameObject> biasMap = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> imageMap = new Dictionary<string, GameObject>();

    private HashSet<string> collectedBias = new HashSet<string>();

    private void Start()
    {


        for (int i = 0; i < biasPlaceholders.Count; i++)
        {
            string tagName = "bias" + (i + 1);

            if (biasPlaceholders[i] != null)
                biasMap[tagName] = biasPlaceholders[i];

            if (i < biasImages.Count && biasImages[i] != null)
                imageMap[tagName] = biasImages[i];
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (biasMap.ContainsKey(other.tag) && !collectedBias.Contains(other.tag))
        {
            Debug.Log(other.tag + " pick up");
            other.gameObject.SetActive(false);
            collectedBias.Add(other.tag);

            if (imageMap.ContainsKey(other.tag))
            {
                imageMap[other.tag].SetActive(true);
            }

            GameObject displayObject = biasMap[other.tag];
            if (displayObject != null)
            {
                StartCoroutine(ShowAndHide(displayObject, 3f));
            }

            if (collectedBias.Count == biasMap.Count)
            {
                Debug.Log("ALLDONE");
                completeCanvas.SetActive(true);
                checkTask.SetActive(true);
            }
        }
    }

    private IEnumerator ShowAndHide(GameObject obj, float delay)
    {
        obj.SetActive(true);
        yield return new WaitForSeconds(delay);
        obj.SetActive(false);
    }
}
