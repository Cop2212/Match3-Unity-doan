using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    private const string SOUND_KEY = "prefs_key_sound";

    public bool IsSoundOn { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            IsSoundOn = PlayerPrefs.GetInt(SOUND_KEY, 1) == 1;
            ApplySound();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ToggleSound()
    {
        IsSoundOn = !IsSoundOn;
        PlayerPrefs.SetInt(SOUND_KEY, IsSoundOn ? 1 : 0);
        PlayerPrefs.Save();
        ApplySound();
    }

    public void ApplySound()
    {
        AudioListener.volume = IsSoundOn ? 1f : 0f;
    }
}
