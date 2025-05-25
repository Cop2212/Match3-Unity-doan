using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Background Music")]
    public AudioClip backgroundMusic;
    private AudioSource bgmSource;

    private void Awake()
    {
        // Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitAudio();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitAudio()
    {
        bgmSource = gameObject.AddComponent<AudioSource>();
        bgmSource.clip = backgroundMusic;
        bgmSource.loop = true;
        bgmSource.playOnAwake = false;
        bgmSource.volume = 0.5f; // Tùy chỉnh
        bgmSource.Play();
    }

    public void SetVolume(float volume)
    {
        bgmSource.volume = Mathf.Clamp01(volume);
    }

    public void PauseBGM() => bgmSource.Pause();
    public void ResumeBGM() => bgmSource.UnPause();
}
