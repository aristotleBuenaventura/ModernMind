using UnityEngine;
using System.Collections;
using TMPro; 

public class CloseCanvas : MonoBehaviour
{
    public GameObject QuestionWall, choice1, choice2;
    public TextMeshProUGUI countdownText; 

    void Start()
    {
        StartCoroutine(CountdownAndReveal());
    }

    IEnumerator CountdownAndReveal()
    {
        int seconds = 1;

        while (seconds > 0)
        {
            countdownText.text = seconds + "s";
            yield return new WaitForSeconds(1f);
            seconds--;
        }

        countdownText.text = "0s";

        QuestionWall.SetActive(false);
        choice1.SetActive(true);
        choice2.SetActive(true);
        Debug.Log("DONE");
    }
}
