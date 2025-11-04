using UnityEngine;
using UnityEngine.UI;

public class SceneVolumeLink : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource sceneAudio;

    void Start()
    {
        if (volumeSlider != null && GlobalVolumeManager.Instance != null)
        {
            volumeSlider.value = GlobalVolumeManager.Instance.GetVolume();
            volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        }

        ApplyVolume(GlobalVolumeManager.Instance != null ? GlobalVolumeManager.Instance.GetVolume() : 1f);
    }

    void OnVolumeChanged(float value)
    {
        if (GlobalVolumeManager.Instance != null)
            GlobalVolumeManager.Instance.SetVolume(value);

        ApplyVolume(value);
    }

    void ApplyVolume(float value)
    {
        if (sceneAudio != null)
            sceneAudio.volume = value;
    }

    void OnDestroy()
    {
        if (volumeSlider != null)
            volumeSlider.onValueChanged.RemoveListener(OnVolumeChanged);
    }
}
