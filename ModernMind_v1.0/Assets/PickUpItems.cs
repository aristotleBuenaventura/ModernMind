using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickUpItems : MonoBehaviour
{
    [Header("Collected Trash Placeholders (3D)")]
    public List<GameObject> trashPlaceholders;  // for showing collected trash objects in world

    [Header("Trash UI Images")]
    public List<GameObject> trashImages; // for showing corresponding UI images

    [Header("Other UI Objects")]
    public GameObject trashCircle;
    public GameObject check, tumpak;
    public ShowUI taskCanvas;

    private Dictionary<string, GameObject> trashMap = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> imageMap = new Dictionary<string, GameObject>();

    private HashSet<string> collectedTrash = new HashSet<string>();
    public Scene1CanvasManager canvas;
    private void Start()
    {
        trashCircle.SetActive(false);

        // Build maps dynamically from list indexes
        for (int i = 0; i < trashPlaceholders.Count; i++)
        {
            string tagName = "trash" + (i + 1); // expects tags like trash1, trash2, trash3...

            if (trashPlaceholders[i] != null)
                trashMap[tagName] = trashPlaceholders[i];

            if (i < trashImages.Count && trashImages[i] != null)
                imageMap[tagName] = trashImages[i];
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (trashMap.ContainsKey(other.tag) && !collectedTrash.Contains(other.tag))
        {
            Debug.Log(other.tag + " pick up");
            other.gameObject.SetActive(false);
            collectedTrash.Add(other.tag);

            // Show corresponding UI image
            if (imageMap.ContainsKey(other.tag))
            {
                imageMap[other.tag].SetActive(true);

                // Show tumpak ONLY if this is NOT the last item
                if (collectedTrash.Count + 1 < trashMap.Count)
                {
                    tumpak.SetActive(true);
                }
            }


            // Show & hide placeholder
            GameObject displayObject = trashMap[other.tag];
            if (displayObject != null)
            {
                StartCoroutine(ShowAndHide(displayObject, 3f));
            }

            // Check if all trash collected
            if (collectedTrash.Count == trashMap.Count)
            {
                Debug.Log("ALLDONE");
                // taskCanvas.UICanvasShow();
                canvas.Cut2Show();
                trashCircle.SetActive(true);
                check.SetActive(true);
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
