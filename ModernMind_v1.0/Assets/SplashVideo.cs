using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SplashVideo : MonoBehaviour
{
    public string nextScene = "MainMenu";
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene(nextScene);
    }
}
