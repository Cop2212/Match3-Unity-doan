using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Background Musics")]
    public AudioClip homeBGM;
    public AudioClip gameBGM;

    [Header("Sound Effects")]
    public AudioClip swapSFX;
    public AudioClip matchSFX;
    public AudioClip moveDownSFX;
    public AudioClip clickSFX;

    [Range(0f, 1f)]
    public float swapVolume = 1f;

    [Range(0f, 1f)]
    public float matchVolume = 1f;

    [Range(0f, 1f)]
    public float moveDownVolume = 1f;

    private AudioSource sfxSource;

    private AudioSource bgmSource;

    private void Awake()
    {
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
        // BGM Source
        bgmSource = gameObject.AddComponent<AudioSource>();
        bgmSource.loop = true;
        bgmSource.playOnAwake = false;

        // SFX Source
        sfxSource = gameObject.AddComponent<AudioSource>();
        sfxSource.playOnAwake = false;
        sfxSource.loop = false;
    }

    public void PlayHomeBGM()
    {
        if (bgmSource.clip != homeBGM)
        {
            bgmSource.clip = homeBGM;
            bgmSource.volume = 0.25f;
            bgmSource.Play();
        }
    }

    public void PlayGameBGM()
    {
        if (bgmSource.clip != gameBGM)
        {
            bgmSource.clip = gameBGM;
            bgmSource.volume = 0.5f;
            bgmSource.Play();
        }
    }

    public void StopBGM() => bgmSource.Stop();

    public void SetVolume(float volume)
    {
        bgmSource.volume = Mathf.Clamp01(volume);
    }

    public void PlaySwapSFX()
    {
        if (swapSFX != null && sfxSource != null)
        {
            sfxSource.PlayOneShot(swapSFX, swapVolume);
        }
    }

    public void PlayMatchSFX()
    {
        if (matchSFX != null && sfxSource != null)
        {
            sfxSource.PlayOneShot(matchSFX, matchVolume);
        }
    }

    public void PlayMoveDownSFX()
    {
        if (moveDownSFX != null && sfxSource != null)
        {
            sfxSource.PlayOneShot(moveDownSFX, moveDownVolume);
        }
    }

    public void PlayClickSFX()
    {
        if (clickSFX != null && sfxSource != null)
        {
            sfxSource.PlayOneShot(clickSFX, 1f);
        }
    }

    public void PauseBGM() => bgmSource.Pause();
    public void ResumeBGM() => bgmSource.UnPause();
}
