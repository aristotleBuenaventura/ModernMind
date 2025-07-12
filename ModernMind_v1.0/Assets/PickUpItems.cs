using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickUpItems : MonoBehaviour
{
    [Header("Collected Trash Placeholders")]
    public GameObject trash1;
    public GameObject trash2;
    public GameObject trash3;

    [Header("Trash UI Images")]
    public GameObject trash1Image;
    public GameObject trash2Image;
    public GameObject trash3Image;

    public GameObject trashCircle;

    public GameObject check;
    public ShowUI taskCanvas;
    private Dictionary<string, GameObject> trashMap;
    private Dictionary<string, GameObject> imageMap;

    private HashSet<string> collectedTrash = new HashSet<string>();

    private void Start()
    {
        trashCircle.SetActive(false);
        trashMap = new Dictionary<string, GameObject>
        {
            { "trash1", trash1 },
            { "trash2", trash2 },
            { "trash3", trash3 }
        };

        imageMap = new Dictionary<string, GameObject>
        {
            { "trash1", trash1Image },
            { "trash2", trash2Image },
            { "trash3", trash3Image }
        };
    }

    private void OnTriggerEnter(Collider other)
    {
        if (trashMap.ContainsKey(other.tag) && !collectedTrash.Contains(other.tag))
        {
            Debug.Log(other.tag + " pick up");
            other.gameObject.SetActive(false);
            collectedTrash.Add(other.tag);

            // Show corresponding image
            if (imageMap.ContainsKey(other.tag))
            {
                imageMap[other.tag].SetActive(true);
            }

            // Optional: show and hide 3D placeholder object
            GameObject displayObject = trashMap[other.tag];
            if (displayObject != null)
            {
                StartCoroutine(ShowAndHide(displayObject, 3f));
            }

            if (collectedTrash.Count == trashMap.Count)
            {
                Debug.Log("ALLDONE");
                taskCanvas.UICanvasShow();
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
