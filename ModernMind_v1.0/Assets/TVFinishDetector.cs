using UnityEngine;
using UnityEngine.Video;

public class TVFinishDetector : MonoBehaviour
{
    public VideoPlayer videoSource;
    public Scene1CanvasManager canvas;
    public GameObject TV;

    void Start()
    {
        if (videoSource != null)
        {
            videoSource.loopPointReached += OnVideoFinished;
        }
        else
        {
            Debug.LogWarning("VideoSource is not assigned.");
        }
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        Debug.Log("DONE");
        canvas.SeventeenthCanvasShow();
        TV.SetActive(false);
    }
}
