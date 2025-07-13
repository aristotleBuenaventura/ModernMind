using UnityEngine;
using System.Collections;

public class CloseCanvas : MonoBehaviour
{
    public GameObject QuestionWall;

    void Start()
    {
        StartCoroutine(DelayedDoneLog());
    }

    IEnumerator DelayedDoneLog()
    {
        yield return new WaitForSeconds(10f); // Wait for 10 seconds
        QuestionWall.SetActive(false);  
    }
}
