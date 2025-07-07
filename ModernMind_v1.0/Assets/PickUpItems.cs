using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickUpItems : MonoBehaviour
{
    [Header("Collected Trash Placeholders")]
    public GameObject trash1;
    public GameObject trash2;
    public GameObject trash3;

    private Dictionary<string, GameObject> trashMap;

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
        if (trashMap.ContainsKey(other.tag))
        {
            Debug.Log("Done");
            other.gameObject.SetActive(false);

            GameObject displayObject = trashMap[other.tag];
            if (displayObject != null)
            {
                StartCoroutine(ShowAndHide(displayObject, 3f));
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
