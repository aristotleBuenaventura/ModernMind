using UnityEngine;

public class GlobalVolumeManager : MonoBehaviour
{
    public static GlobalVolumeManager Instance;
    private const string VolumeKey = "MasterVolume";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            float savedVolume = PlayerPrefs.GetFloat(VolumeKey, 1f);
            AudioListener.volume = savedVolume;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetVolume(float value)
    {
        AudioListener.volume = value;
        PlayerPrefs.SetFloat(VolumeKey, value);
        PlayerPrefs.Save();
    }

    public float GetVolume()
    {
        return AudioListener.volume;
    }
}
