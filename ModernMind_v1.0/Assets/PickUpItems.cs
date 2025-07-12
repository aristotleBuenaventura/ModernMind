using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickUpItems : MonoBehaviour
{
    [Header("Collected Trash Placeholders")]
    public GameObject trash1;
    public GameObject trash2;
    public GameObject trash3;
    public GameObject check;
    private Dictionary<string, GameObject> trashMap;
    private HashSet<string> collectedTrash = new HashSet<string>();

    private void Start()
    {
        trashMap = new Dictionary<string, GameObject>
        {
            { "trash1", trash1 },
            { "trash2", trash2 },
            { "trash3", trash3 }
        };
    }

    private void OnTriggerEnter(Collider other)
    {
        if (trashMap.ContainsKey(other.tag) && !collectedTrash.Contains(other.tag))
        {
            Debug.Log("Done");
            other.gameObject.SetActive(false);

            collectedTrash.Add(other.tag); // Track collected trash

            GameObject displayObject = trashMap[other.tag];
            if (displayObject != null)
            {
                StartCoroutine(ShowAndHide(displayObject, 3f));
            }

            if (collectedTrash.Count == trashMap.Count)
            {
                Debug.Log("ALLDONE");
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
