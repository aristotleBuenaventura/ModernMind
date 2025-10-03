using System.Collections;
using UnityEngine;

public class SequentialAudioPlayer : MonoBehaviour
{
    public AudioSource audioSource;          // AudioSource component
    public AudioClip[] audioClips;           // Array ng audio clips

    private int currentIndex = 0;

    void Start()
    {
        if (audioClips.Length > 0 && audioSource != null)
        {
            StartCoroutine(PlayAudioSequentially());
        }
        else
        {
            Debug.LogWarning("Missing AudioSource or AudioClips!");
        }
    }

    IEnumerator PlayAudioSequentially()
    {
        while (currentIndex < audioClips.Length)
        {
            audioSource.clip = audioClips[currentIndex];
            audioSource.Play();

            // Maghintay hanggang matapos ang kasalukuyang clip
            yield return new WaitForSeconds(audioSource.clip.length);

            currentIndex++;
        }
    }
}
